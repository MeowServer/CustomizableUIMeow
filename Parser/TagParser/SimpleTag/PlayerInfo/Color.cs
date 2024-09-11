using CustomizableUIMeow.Parser.TagParser;
using CustomizableUIMeow.Parser.TagParser.ParserUtilities;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.PlayerInfo
{
    public class Color
    {
        [TagParser("PRankColor")]
        public object RankColor(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).RankColor;

        [TagParser("PVoiceColor")]
        public object VoiceColor(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).VoiceColor.ToHex();

        [TagParser("PRoleColor")]
        public object RoleColor(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).Role.Color.ToHex();
    }
}
