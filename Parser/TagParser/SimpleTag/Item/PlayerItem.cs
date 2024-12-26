﻿using CustomizableUIMeow.Parser.TagParser;
using CustomizableUIMeow.Parser.TagParser.ParserUtilities;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.Item
{
    public class Item
    {
        [TagParser("IName")]
        public string Name(TagParserParameter parameter) => NameTranslator.GetName(parameter.Player.CurrentItem.Type);

        [TagParser("IType")]
        public string Type(TagParserParameter parameter) => parameter.Player.CurrentItem.Type.ToString();

        [TagParser("ICategory")]
        public string Category(TagParserParameter parameter) => parameter.Player.CurrentItem.Category.ToString();
    }
}
