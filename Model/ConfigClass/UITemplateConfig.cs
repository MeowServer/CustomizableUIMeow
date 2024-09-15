using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerRoles;

namespace CustomizableUIMeow.Model
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
