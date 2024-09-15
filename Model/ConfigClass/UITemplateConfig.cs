using System;
using System.Collections.Generic;
using PlayerRoles;

namespace CustomizableUIMeow.Model.ConfigClass
{
    public class UITemplateConfig
    {
        public List<RoleTypeId> AppliedRole { get; set; } = new List<RoleTypeId>((RoleTypeId[])Enum.GetValues(typeof(RoleTypeId)));

        public List<Object> Elements { get; set; } = new List<Object>()
        {
            "Your element name",
        };
    }
}
