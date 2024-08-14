using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomizableUIMeow.Parser.TagParser.Player;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.PlayerInfo
{
    public class Color
    {
        [TagParser("PRankColor")]
        public string RankColor(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).RankColor;

        [TagParser("PVoiceColor")]
        public string VoiceColor(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).VoiceColor.ToHex();

        [TagParser("PRoleColor")]
        public string RoleColor(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).Role.Color.ToHex();
    }
}
