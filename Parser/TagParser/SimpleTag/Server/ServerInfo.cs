namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.Server
{
    using CustomizableUIMeow.Parser.TagParser;
    using Exiled.API.Features;

    public class ServerInfo
    {
        [TagParser("STPS")]
        public string TPS(TagParserParameter parameter) => Server.Tps.ToString("0.#");

        [TagParser("SIP")]
        public string IP(TagParserParameter parameter) => Server.IpAddress.ToString();

        [TagParser("SPort")]
        public string Port(TagParserParameter parameter) => Server.Port.ToString();

        [TagParser("SName")]
        public string Name(TagParserParameter parameter) => Server.Name.ToString();

        [TagParser("SVersion")]
        public string Version(TagParserParameter parameter) => Server.Version.ToString();

        [TagParser("SMaxPlayerCount")]
        public string MaxPlayerCount(TagParserParameter parameter) => Server.MaxPlayerCount.ToString();

        [TagParser("SPlayerCount")]
        public string PlayerCount(TagParserParameter parameter) => Server.PlayerCount.ToString();
    }
}
