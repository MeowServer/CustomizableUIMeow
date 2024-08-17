using CustomizableUIMeow.Parser.TagParser;
using CustomizableUIMeow.Parser.TagParser.ParserUtilities;

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
