using Geesemon.GraphQL.Client.Abstraction;
using GraphQL.Types;
using System.Collections.Generic;

namespace Geesemon.GraphQL.Client
{
    public class ClientMutations : ObjectGraphType
    {
        public ClientMutations(IEnumerable<IClientMutationMarker> clientMutationMarkers)
        {
            Name = "ClientMutations";

            foreach (var clientMutationMarker in clientMutationMarkers)
            {
                var marker = clientMutationMarker as ObjectGraphType<object>;
                foreach (var field in marker.Fields)
                    AddField(field);
            }
        }
    }
}
