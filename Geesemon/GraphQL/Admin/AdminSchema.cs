using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Geesemon.GraphQL.Admin
{
    public class AdminSchema : Schema
    {
        public AdminSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<AdminQueries>();
            Mutation = provider.GetRequiredService<AdminMutations>();
        }
    }
}
