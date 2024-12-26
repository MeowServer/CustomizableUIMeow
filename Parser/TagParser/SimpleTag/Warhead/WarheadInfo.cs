namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.Warhead
{
    using CustomizableUIMeow.Parser.TagParser;
    using CustomizableUIMeow.Parser.TagParser.ParserUtilities;
    using Exiled.API.Features;

    public class WarheadInfo
    {
        [TagParser("WStatus")]
        public string Status(TagParserParameter parameter) => NameTranslator.GetName(Warhead.Status);

        [TagParser("WTimer")]
        public string Timer(TagParserParameter parameter) => Warhead.DetonationTimer.ToString("0.#");

    }
}
