using Geesemon.GraphQL.Client.Abstraction;
using GraphQL.Types;
using System.Collections.Generic;

namespace Geesemon.GraphQL.Client
{
    public class ClientQueries : ObjectGraphType
    {
        public ClientQueries(IEnumerable<IClientQueryMarker> clientQueryMarkers)
        {
            Name = "ClientQueries";

            foreach (var clientQueryMarker in clientQueryMarkers)
            {
                var marker = clientQueryMarker as ObjectGraphType<object>;
                foreach (var field in marker.Fields)
                    AddField(field);
            }
        }
    }
}
