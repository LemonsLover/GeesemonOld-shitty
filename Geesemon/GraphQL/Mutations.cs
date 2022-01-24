using Geesemon.GraphQL.Abstraction;
using GraphQL.Types;
using System.Collections.Generic;

namespace Geesemon.GraphQL
{
    public class Mutations : ObjectGraphType
    {
        public Mutations(IEnumerable<IClientMutationMarker> clientMutationMarkers)
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
