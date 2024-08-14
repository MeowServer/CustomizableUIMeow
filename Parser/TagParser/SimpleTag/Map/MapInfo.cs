namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.Map
{
    using Exiled.API.Features;

    public class MapInfo
    {
        [TagParser("MSeed")]
        public string Seed(TagParserParameter parameter) => Map.Seed.ToString();
    }
}
