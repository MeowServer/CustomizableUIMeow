using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomizableUIMeow.Parser.TagParser.ParserUtilities;
using CustomizableUIMeow.Parser.TagParser.Player;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.PlayerInfo
{
    public class RoleInfo
    {
        [TagParser("PRoleName")]
        public string Name(TagParserParameter parameter) => NameTranslator.GetName(PlayerGetter.GetPlayer(parameter).Role.Type);

        [TagParser("PRoleActiveTime")]
        public string ActiveTime(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).Role.ActiveTime.ToString(parameter.Arguments.Length == 0 ? "g" : parameter.Arguments.First());

        [TagParser("PRoleType")]
        public string Type(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).Role.Type.ToString();
    }
}
