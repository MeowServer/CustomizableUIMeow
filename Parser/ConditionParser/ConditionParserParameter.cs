using Exiled.API.Features;
using System.Collections.Generic;

namespace CustomizableUIMeow.Parser.ConditionParser
{
    public class ConditionParserParameter
    {
        public Player Player { get; }

        public ConditionParserParameter(Player player)
        {
            Player = player;
        }

        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                {"Player", Player }
            };
        }
    }
}
