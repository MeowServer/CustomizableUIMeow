using CustomizableUIMeow.Parser.TagParser;
using CustomizableUIMeow.Parser.TagParser.ParserUtilities;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.PlayerInfo
{
    public class Role
    {
        [TagParser("PRoleName")]
        public object Name(TagParserParameter parameter) => NameTranslator.GetName(PlayerGetter.GetPlayer(parameter).Role.Type);

        [TagParser("PRoleActiveTime")]
        public object ActiveTime(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).Role.ActiveTime.ToString(@"mm/:ss");

        [TagParser("PRoleType")]
        public object Type(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).Role.Type.ToString();
    }
}
