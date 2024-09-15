using CustomizableUIMeow.Parser.SimpleTag.TagParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CustomizableUIMeow.Parser.TagParser.HelperTag
{
    public class ColorHelper
    {
        private string lastColor = "FFFFFF";
        private DateTime LastTimeUpdate = DateTime.MinValue;

        [TagParser("RandomColor")]
        public string RandomColor(TagParserParameter parameter)
        {
            string color = lastColor;

            if (DateTime.Now - LastTimeUpdate > TimeSpan.FromSeconds(1))
            {
                color = "#" + UnityEngine.Random.Range(0, 0xFFFFFF).ToString("X6");

                lastColor = color;
                LastTimeUpdate = DateTime.Now;
            }

            return color;
        }
    }
}
