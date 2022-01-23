using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Geesemon.GraphQL.Client
{
    public class ClientSchema : Schema
    {
        public ClientSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<ClientQueries>();
            Mutation = provider.GetRequiredService<ClientMutations>();
        }
    }
}
