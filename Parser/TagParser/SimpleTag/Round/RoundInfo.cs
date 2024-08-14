namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.Round
{
    using CustomizableUIMeow.Parser.TagParser.ParserUtilities;
    using Exiled.API.Features;

    public class RoundInfo
    {
        [TagParser("RElapsedTime")]
        public string ElapsedTime(TagParserParameter parameter) => Round.ElapsedTime.ToString(@"mm\:ss");

        [TagParser("RChangedIntoZombies")]
        public string ChangedIntoZombies(TagParserParameter parameter) => Round.ChangedIntoZombies.ToString();

        [TagParser("RChaosTargetCounte")]
        public string ChaosTargetCount(TagParserParameter parameter) => Round.ChaosTargetCount.ToString();

        [TagParser("REscapedDClasses")]
        public string EscapedDClasses(TagParserParameter parameter) =>Round.EscapedDClasses.ToString();

        [TagParser("REscapedScientists")]
        public string EscapedScientists(TagParserParameter parameter) => Round.EscapedScientists.ToString();

        [TagParser("RKills")]
        public string Kills(TagParserParameter parameter) => Round.Kills.ToString();

        [TagParser("RKillsByScp")]
        public string KillsByScp(TagParserParameter parameter) => Round.KillsByScp.ToString();

        [TagParser("RLobbyWaitingTime")]
        public string LobbyWaitingTime(TagParserParameter parameter) => (Round.LobbyWaitingTime >= 0 ? Round.LobbyWaitingTime : 0).ToString();

        [TagParser("RStartedTime")]
        public string StartedTime(TagParserParameter parameter) => Round.StartedTime.ToString(@"t");

        [TagParser("RSurvivingSCPs")]
        public string SurvivingSCPs(TagParserParameter parameter) => Round.SurvivingSCPs.ToString();

        [TagParser("RUptimeRounds")]
        public string UptimeRounds(TagParserParameter parameter) => Round.UptimeRounds.ToString();
    }
}
