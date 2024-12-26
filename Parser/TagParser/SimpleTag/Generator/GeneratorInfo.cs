using System.Linq;

namespace CustomizableUIMeow.Parser.TagParser.SimpleTag.Generator
{
    public class GeneratorInfo
    {
        [TagParser("GTotalCount")]
        public string TotalCount(TagParserParameter parameter) => Exiled.API.Features.Generator.List.Count.ToString();

        [TagParser("GActivatedCount")]
        public string ActivatedCount(TagParserParameter parameter) => Exiled.API.Features.Generator.List.Count(x => x.IsActivating).ToString();
    }
}
