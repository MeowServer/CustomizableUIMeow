using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableUIMeow.Parser.TagParser
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TagParserAttribute : Attribute
    {
        public string TagName { get; }

        public TagParserAttribute(string tagName)
        {
            TagName = tagName;
        }
    }
}
