using CustomizableUIMeow.Parser.TagParser;
using CustomizableUIMeow.Parser.TagParser.ParserUtilities;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.PlayerInfo
{
    public class Team
    {
        [TagParser("PLeadingTeam")]
        public string LeadingTeam(TagParserParameter parameter) => NameTranslator.GetName(PlayerGetter.GetPlayer(parameter).LeadingTeam);

        [TagParser("PTeam")]
        public string TeamType(TagParserParameter parameter) => NameTranslator.GetName(PlayerGetter.GetPlayer(parameter).Role.Team);
    }
}
