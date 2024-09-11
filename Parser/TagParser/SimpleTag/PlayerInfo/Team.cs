using CustomizableUIMeow.Parser.TagParser;
using CustomizableUIMeow.Parser.TagParser.ParserUtilities;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.PlayerInfo
{
    public class Team
    {
        [TagParser("PLeadingTeam")]
        public object LeadingTeam(TagParserParameter parameter) => NameTranslator.GetName(PlayerGetter.GetPlayer(parameter).LeadingTeam);

        [TagParser("PTeam")]
        public object TeamType(TagParserParameter parameter) => NameTranslator.GetName(PlayerGetter.GetPlayer(parameter).Role.Team);
    }
}
