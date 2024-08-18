using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomizableUIMeow.Parser.SimpleTag.TagParser;

namespace CustomizableUIMeow.Parser.TagParser.ParserUtilities
{
    public static class ParamHelper
    {
        public static string GetOrDefault(TagParserParameter parameter, int index, string defaultStr)
        {
            if (parameter.Arguments.TryGet(index, out string str))
            {
                return str;
            }

            return defaultStr;
        }
    }
}
