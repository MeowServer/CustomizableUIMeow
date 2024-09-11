namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.Map
{
    using CustomizableUIMeow.Parser.TagParser;
    using Exiled.API.Features;

    public class MapInfo
    {
        [TagParser("MSeed")]
        public object Seed(TagParserParameter parameter) => Map.Seed.ToString();
    }
}
