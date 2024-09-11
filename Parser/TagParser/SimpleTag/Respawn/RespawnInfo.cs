using CustomizableUIMeow.Parser.TagParser.ParserUtilities;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.Respawn
{
    using CustomizableUIMeow.Parser.TagParser;
    using Exiled.API.Features;

    public class RespawnInfo
    {
        [TagParser("RSChaosTickets")]
        public object ChaosTickets(TagParserParameter parameter) => Respawn.ChaosTickets.ToString("0");

        [TagParser("RSNtfTickets")]
        public object NtfTickets(TagParserParameter parameter) => Respawn.NtfTickets.ToString("0");

        [TagParser("RSNextKnownTeam")]
        public object NextKnownTeam(TagParserParameter parameter) => NameTranslator.GetName(Respawn.NextKnownTeam);

        [TagParser("RSNextTeamTime")]
        public object NextTeamTime(TagParserParameter parameter) => Respawn.NextTeamTime.ToString(@"t");

        [TagParser("RSTimeUntilSpawnWave")]
        public object TimeUntilSpawnWave(TagParserParameter parameter) => Respawn.TimeUntilSpawnWave.ToString(@"mm\:ss");
    }
}
