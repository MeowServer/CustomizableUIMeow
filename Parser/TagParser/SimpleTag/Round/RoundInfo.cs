namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.Round
{
    using CustomizableUIMeow.Parser.TagParser;
    using Exiled.API.Features;

    public class RoundInfo
    {
        [TagParser("RElapsedTime")]
        public object ElapsedTime(TagParserParameter parameter) => Round.ElapsedTime.ToString(@"mm\:ss");

        [TagParser("RChangedIntoZombies")]
        public object ChangedIntoZombies(TagParserParameter parameter) => Round.ChangedIntoZombies.ToString();

        [TagParser("RChaosTargetCounte")]
        public object ChaosTargetCount(TagParserParameter parameter) => Round.ChaosTargetCount.ToString();

        [TagParser("REscapedDClasses")]
        public object EscapedDClasses(TagParserParameter parameter) =>Round.EscapedDClasses.ToString();

        [TagParser("REscapedScientists")]
        public object EscapedScientists(TagParserParameter parameter) => Round.EscapedScientists.ToString();

        [TagParser("RKills")]
        public object Kills(TagParserParameter parameter) => Round.Kills.ToString();

        [TagParser("RKillsByScp")]
        public object KillsByScp(TagParserParameter parameter) => Round.KillsByScp.ToString();

        [TagParser("RLobbyWaitingTime")]
        public object LobbyWaitingTime(TagParserParameter parameter) => (Round.LobbyWaitingTime >= 0 ? Round.LobbyWaitingTime : 0).ToString();

        [TagParser("RStartedTime")]
        public object StartedTime(TagParserParameter parameter) => Round.StartedTime.ToString(@"t");

        [TagParser("RSurvivingSCPs")]
        public object SurvivingSCPs(TagParserParameter parameter) => Round.SurvivingSCPs.ToString();

        [TagParser("RUptimeRounds")]
        public object UptimeRounds(TagParserParameter parameter) => Round.UptimeRounds.ToString();
    }
}
