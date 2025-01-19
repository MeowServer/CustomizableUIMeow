using CustomizableUIMeow.Parser.TagParser.ParserUtilities;

namespace CustomizableUIMeow.Parser.TagParser.SimpleTag.PlayerInfo
{
    public class Info
    {
        [TagParser("PCustomInfo")]
        public object CustomInfo(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).CustomInfo;
    }
}
