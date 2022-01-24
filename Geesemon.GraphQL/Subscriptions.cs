using Geesemon.GraphQL.Abstraction;
using GraphQL.Types;
using System.Collections.Generic;

namespace Geesemon.GraphQL
{
    public class Subscriptions : ObjectGraphType
    {
        public Subscriptions(IEnumerable<IClientSubscriptionMarker> clientSubscriptionMarkers)
        {
            Name = "Subscriptions";

            foreach (var clientSubscriptionMarker in clientSubscriptionMarkers)
            {
                var marker = clientSubscriptionMarker as ObjectGraphType<object>;
                foreach (var field in marker.Fields)
                    AddField(field);
            }
        }
    }
}
