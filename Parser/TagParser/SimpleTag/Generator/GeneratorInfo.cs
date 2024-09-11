using CustomizableUIMeow.Parser.SimpleTag.TagParser;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableUIMeow.Parser.TagParser.SimpleTag.Generator
{
    public class GeneratorInfo
    {
        [TagParser("GTotalCount")]
        public object TotalCount(TagParserParameter parameter) => Exiled.API.Features.Generator.List.Count;

        [TagParser("GActivatedCount")]
        public object ActivatedCount(TagParserParameter parameter) => Exiled.API.Features.Generator.List.Count(x => x.IsActivating);
    }
} 
