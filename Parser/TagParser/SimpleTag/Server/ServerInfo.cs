namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.Server
{
    using CustomizableUIMeow.Parser.TagParser;
    using CustomizableUIMeow.Parser.TagParser.ParserUtilities;
    using Exiled.API.Features;

    public class ServerInfo
    {
        [TagParser("STPS")]
        public object TPS(TagParserParameter parameter) => Server.Tps.ToString("0.#");

        [TagParser("SIP")]
        public object IP(TagParserParameter parameter) => Server.IpAddress.ToString();

        [TagParser("SPort")]
        public object Port(TagParserParameter parameter) => Server.Port.ToString();

        [TagParser("SName")]
        public object Name(TagParserParameter parameter) => Server.Name.ToString();

        [TagParser("SVersion")]
        public object Version(TagParserParameter parameter) => Server.Version.ToString();

        [TagParser("SMaxPlayerCount")]
        public object MaxPlayerCount(TagParserParameter parameter) => Server.MaxPlayerCount.ToString();

        [TagParser("SPlayerCount")]
        public object PlayerCount(TagParserParameter parameter) => Server.PlayerCount.ToString();
    }
}
