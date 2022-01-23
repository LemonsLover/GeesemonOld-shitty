using Geesemon.GraphQL.Admin.Abstraction;
using GraphQL.Types;
using System.Collections.Generic;

namespace Geesemon.GraphQL.Admin
{
    public class AdminQueries : ObjectGraphType
    {
        public AdminQueries(IEnumerable<IAdminQueryMarker> adminQueryMarkers)
        {
            Name = "AdminQueries";

            foreach (var adminQueryMarker in adminQueryMarkers)
            {
                var marker = adminQueryMarker as ObjectGraphType<object>;
                foreach (var field in marker.Fields)
                    AddField(field);
            }
        }
    }
}
