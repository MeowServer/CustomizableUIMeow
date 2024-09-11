namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.Warhead
{
    using CustomizableUIMeow.Parser.TagParser.ParserUtilities;
    using CustomizableUIMeow.Parser.TagParser;
    using Exiled.API.Features;

    public class WarheadInfo
    {
        [TagParser("WStatus")]
        public object Status(TagParserParameter parameter) => NameTranslator.GetName(Warhead.Status);

        [TagParser("WTimer")]
        public object Timer(TagParserParameter parameter) => Warhead.DetonationTimer.ToString("0.#");
    }
}
