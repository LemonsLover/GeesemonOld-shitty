using Geesemon.GraphQL.Admin.Abstraction;
using GraphQL.Types;
using System.Collections.Generic;

namespace Geesemon.GraphQL.Admin
{
    public class AdminMutations : ObjectGraphType
    {
        public AdminMutations(IEnumerable<IAdminMutationMarker> adminMutationMarkers)
        {
            Name = "AdminMutations";

            foreach (var adminMutationMarker in adminMutationMarkers)
            {
                var marker = adminMutationMarker as ObjectGraphType<object>;
                foreach (var field in marker.Fields)
                    AddField(field);
            }
        }
    }
}
