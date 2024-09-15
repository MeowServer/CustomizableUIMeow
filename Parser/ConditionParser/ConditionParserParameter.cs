using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
