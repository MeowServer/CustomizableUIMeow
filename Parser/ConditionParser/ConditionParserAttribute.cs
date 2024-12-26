using System;

namespace CustomizableUIMeow.Parser.ConditionParser
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ConditionParserAttribute : Attribute
    {
        public string ConditionName { get; }

        public ConditionParserAttribute(string conditionName)
        {
            ConditionName = conditionName;
        }
    }
}
