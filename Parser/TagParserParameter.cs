using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;

namespace CustomizableUIMeow.Parser.TagParser
{
    public class TagParserParameter
    {
        public readonly string TagName;

        public readonly Player Player;

        public readonly Queue<string> Arguments;

        public TagParserParameter(Exiled.API.Features.Player player, string tagName, Queue<string> arguments)
        {
            this.Player = player;
            this.TagName = tagName;
            this.Arguments = arguments;
        }

        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>
            {
                { "Player", Player },
                { "TagName", TagName },
                { "Arguments", Arguments }
            };

            return dictionary;
        }
    }
}
