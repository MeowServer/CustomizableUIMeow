using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomizableUIMeow.Parser.TagParser.ParserUtilities;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.Warhead
{
    using Exiled.API.Features;

    public class WarheadInfo
    {
        [TagParser("WStatus")]
        public string Status(TagParserParameter parameter) => NameTranslator.GetName(Warhead.Status);

        [TagParser("WTimer")]
        public string Timer(TagParserParameter parameter) => Warhead.DetonationTimer.ToString("0.#");

    }
}
