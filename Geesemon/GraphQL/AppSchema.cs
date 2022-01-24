using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Geesemon.GraphQL
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<Queries>();
            Mutation = provider.GetRequiredService<Mutations>();
            Subscription = provider.GetRequiredService<Subscriptions>();
        }
    }
}
