using Geesemon.Database;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL.Admin;
using Geesemon.GraphQL.Admin.Abstraction;
using Geesemon.GraphQL.Admin.Roles;
using Geesemon.GraphQL.Admin.Users;
using Geesemon.GraphQL.Client;
using Geesemon.GraphQL.Client.Abstraction;
using Geesemon.Utils;
using GraphQL;
using GraphQL.Server;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;

namespace Geesemon
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDatabaseContext>(options => options.UseMySQL(StringUtils.ConvertConnectionString(Environment.GetEnvironmentVariable("JAWSDB_URL"))));
            services.AddTransient<UsersRepository>();
            services.AddTransient<RolesRepository>();

            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateAudience = true,
                     ValidateIssuer = true,
                     ValidateIssuerSigningKey = true,
                     ValidAudience = Environment.GetEnvironmentVariable("AuthValidAudience"),
                     ValidIssuer = Environment.GetEnvironmentVariable("AuthValidIssuer"),
                     RequireSignedTokens = false,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("AuthIssuerSigningKey"))),
                 };
                 options.RequireHttpsMetadata = false;
                 options.SaveToken = true;
             });

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IAdminQueryMarker, UsersQueries>();
            services.AddTransient<IAdminQueryMarker, RolesQueries>();
            services.AddTransient<IAdminMutationMarker, UsersMutations>();
            services.AddTransient<IAdminMutationMarker, RolesMutations>();

            services.AddTransient<AdminSchema>();
            services
                .AddGraphQL()
                .AddGraphTypes(ServiceLifetime.Transient)
                .AddSystemTextJson()
                .AddWebSockets()
                .AddDataLoader()
                .AddGraphTypes(typeof(AdminSchema))
                .AddGraphQLAuthorization(options =>
                {
                    options.AddPolicy("Authenticated", p => p.RequireAuthenticatedUser());
                    options.AddPolicy("Admin", p => p.RequireClaim(ClaimTypes.Role, "admin"));
                    options.AddPolicy("User", p => p.RequireClaim(ClaimTypes.Role, "user"));
                })
                .AddErrorInfoProvider(options => options.ExposeExceptionStackTrace = true);
            
            
            services.AddTransient<IClientQueryMarker, GraphQL.Client.Users.UsersQueries>();
            services.AddTransient<IClientMutationMarker, GraphQL.Client.Users.UsersMutations>();

            services.AddTransient<ClientSchema>();
            services
                .AddGraphQL()
                .AddGraphTypes(ServiceLifetime.Transient)
                .AddSystemTextJson()
                .AddWebSockets()
                .AddDataLoader()
                .AddGraphTypes(typeof(ClientSchema))
                .AddGraphQLAuthorization(options =>
                {
                    options.AddPolicy("Authenticated", p => p.RequireAuthenticatedUser());
                    options.AddPolicy("Admin", p => p.RequireClaim(ClaimTypes.Role, "admin"));
                    options.AddPolicy("User", p => p.RequireClaim(ClaimTypes.Role, "user"));
                })
                .AddErrorInfoProvider(options => options.ExposeExceptionStackTrace = true);


            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL<AdminSchema>("graphql-admin");
                endpoints.MapGraphQL<ClientSchema>("graphql-client");
                endpoints.MapGraphQLAltair();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
