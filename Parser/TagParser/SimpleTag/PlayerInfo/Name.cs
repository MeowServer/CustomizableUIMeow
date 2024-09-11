using CustomizableUIMeow.Parser.TagParser;
using CustomizableUIMeow.Parser.TagParser.ParserUtilities;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.PlayerInfo
{
    //Start with P
    public class Name
    {
        [TagParser("PNickname")]
        public object Nickname(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).Nickname;

        [TagParser("PCustomName")]
        public object CustomName(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).CustomName;

        [TagParser("PRankName")]
        public object RankName(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).RankName;

        [TagParser("PGroupName")]
        public object GroupName(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).GroupName;

        [TagParser("PUnitName")]
        public object PlayerInfoName(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).UnitName;
    }
}
