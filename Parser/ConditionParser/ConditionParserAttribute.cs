using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableUIMeow.Parser.ConditionParser
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ConditionParserAttribute:Attribute
    {
        public string ConditionName { get; }

        public ConditionParserAttribute(string conditionName)
        {
            ConditionName = conditionName;
        }
    }
}
