using Geesemon.Database;
using Geesemon.Database.Models;
using Geesemon.Database.Repositories;
using Geesemon.GraphQL;
using Geesemon.GraphQL.Abstraction;
using Geesemon.GraphQL.Modules.Auth;
using Geesemon.GraphQL.Modules.Chats;
using Geesemon.GraphQL.Modules.Users;
using Geesemon.GraphQL.Services;
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
            string connectionString;
#if(DEBUG)
            connectionString = "server=localhost;user=root;password=;database=geesemon;";
#else
            connectionString = StringUtils.ConvertConnectionString(Environment.GetEnvironmentVariable("JAWSDB_URL"));
#endif
            services.AddDbContext<AppDatabaseContext>(options => options.UseMySQL(connectionString));
            services.AddScoped<UsersRepository>();
            services.AddScoped<ChatsRepository>();

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
            services.AddTransient<IDocumentExecuter, SubscriptionDocumentExecuter>();

            services.AddTransient<IQueryMarker, UsersQueries>();
            services.AddTransient<IMutationMarker, UsersMutations>();
            services.AddTransient<ISubscriptionMarker, UsersSubscriptions>();
            services.AddSingleton<UserAddedService>();

            services.AddTransient<IQueryMarker, ChatsQueries>();
            services.AddSingleton<ChatsService>();
            
            services.AddTransient<IMutationMarker, AuthMutations>();
            services.AddTransient<AuthService>();

            services.AddTransient<AppSchema>();
            services
                .AddGraphQL(options => options.EnableMetrics = true)
                .AddSystemTextJson()
                .AddWebSockets()
                .AddDataLoader()
                .AddGraphTypes(typeof(AppSchema), ServiceLifetime.Transient)
                .AddGraphQLAuthorization(options =>
                {
                    options.AddPolicy("Authenticated", p => p.RequireAuthenticatedUser());
                    options.AddPolicy("Admin", p => p.RequireClaim(ClaimTypes.Role, RoleEnum.Admin.ToString()));
                    options.AddPolicy("User", p => p.RequireClaim(ClaimTypes.Role, RoleEnum.User.ToString()));
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

            app.UseAuthentication();
            //app.UseAuthorization();

            app.UseWebSockets();
            app.UseGraphQLWebSockets<AppSchema>();
            app.UseGraphQL<AppSchema>();
            app.UseGraphQLAltair();

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
