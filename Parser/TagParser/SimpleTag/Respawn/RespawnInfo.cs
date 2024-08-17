using CustomizableUIMeow.Parser.TagParser.ParserUtilities;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.Respawn
{
    using CustomizableUIMeow.Parser.TagParser;
    using Exiled.API.Features;

    public class RespawnInfo
    {
        [TagParser("RSChaosTickets")]
        public string ChaosTickets(TagParserParameter parameter) => Respawn.ChaosTickets.ToString("0");

        [TagParser("RSNtfTickets")]
        public string NtfTickets(TagParserParameter parameter) => Respawn.NtfTickets.ToString("0");

        [TagParser("RSNextKnownTeam")]
        public string NextKnownTeam(TagParserParameter parameter) => NameTranslator.GetName(Respawn.NextKnownTeam);

        [TagParser("RSNextTeamTime")]
        public string NextTeamTime(TagParserParameter parameter) => Respawn.NextTeamTime.ToString(@"t");

        [TagParser("RSTimeUntilSpawnWave")]
        public string TimeUntilSpawnWave(TagParserParameter parameter) => Respawn.TimeUntilSpawnWave.ToString(@"mm\:ss");
    }
}
