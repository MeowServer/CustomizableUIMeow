using CustomizableUIMeow.Parser.TagParser.ParserUtilities;

namespace CustomizableUIMeow.Parser.TagParser.SimpleTag.Respawn
{
    public class Respawn
    {
        [TagParser("RECurrentState")]
        public string CurrentState(TagParserParameter parameter) => NameTranslator.GetName(Exiled.API.Features.Respawn.CurrentState);

        [TagParser("RENextKnownSpawnableFaction")]
        public string NextKnownSpawnableFaction(TagParserParameter parameter) => NameTranslator.GetName(Exiled.API.Features.Respawn.NextKnownSpawnableFaction);

        [TagParser("REProtectionTime")]
        public string ProtectionTime(TagParserParameter parameter) => Exiled.API.Features.Respawn.ProtectionTime.ToString("0");
    }
}
