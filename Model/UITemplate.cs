using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UserSettings.GUIElements.UserSettingDependency.Dependency;

namespace CustomizableUIMeow.Model
{
    public class UITemplate
    {
        public List<RoleTypeId> AppliedRole { get; set; } = new List<RoleTypeId>();

        public List<ConditionalElement> Elements { get; set; } = new List<ConditionalElement>();

        public class ConditionalElement
        {
            public Func<bool> Condition { get; set; } = () => true;
            public Element Element { get; set; }
        }
    }
}
