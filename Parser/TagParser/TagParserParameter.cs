using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser
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
    }
}
