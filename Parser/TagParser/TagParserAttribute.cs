﻿using System;

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
