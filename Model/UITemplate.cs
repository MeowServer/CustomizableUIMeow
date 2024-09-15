using PlayerRoles;
using System.Collections.Generic;
using CustomizableUIMeow.Parser.ConditionParser;

namespace CustomizableUIMeow.Model
{
    public class UITemplate
    {
        public List<RoleTypeId> AppliedRole { get; set; } = new List<RoleTypeId>();

        public List<ConditionalElement> Elements { get; set; } = new List<ConditionalElement>();

        public class ConditionalElement
        {
            public ConditionParserDelegate Condition { get; set; } = parameter => true;
            public Element Element { get; set; }
        }
    }
}
