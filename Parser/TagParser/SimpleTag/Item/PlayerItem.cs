using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomizableUIMeow.Parser.TagParser;
using CustomizableUIMeow.Parser.TagParser.ParserUtilities;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.Item
{
    public class Item
    {
        [TagParser("IName")]
        public object Name(TagParserParameter parameter) => parameter.Player.CurrentItem.Type;

        [TagParser("IType")]
        public object Type(TagParserParameter parameter) => parameter.Player.CurrentItem.Type.ToString();

        [TagParser("ICategory")]
        public object Category(TagParserParameter parameter) => parameter.Player.CurrentItem.Category.ToString();
    }
}
