using Geesemon.GraphQL.Abstraction;
using GraphQL.Types;
using System.Collections.Generic;

namespace Geesemon.GraphQL
{
    public class Mutations : ObjectGraphType
    {
        public Mutations(IEnumerable<IMutationMarker> clientMutationMarkers)
        {
            Name = "Mutations";

            foreach (var clientMutationMarker in clientMutationMarkers)
            {
                var marker = clientMutationMarker as ObjectGraphType<object>;
                foreach (var field in marker.Fields)
                    AddField(field);
            }
        }
    }
}
