using System.Collections.Generic;
using Exiled.API.Features;

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
