using System;

namespace CustomizableUIMeow.Parser.TagParser.HelperTag
{
    public class ColorHelper
    {
        private string _lastColor = "FFFFFF";
        private DateTime _LastTimeUpdate = DateTime.MinValue;

        [TagParser("RandomColor")]
        public string RandomColor(TagParserParameter parameter)
        {
            string color = _lastColor;

            if (DateTime.Now - _LastTimeUpdate > TimeSpan.FromSeconds(1))
            {
                color = "#" + UnityEngine.Random.Range(0, 0xFFFFFF).ToString("X6");

                _lastColor = color;
                _LastTimeUpdate = DateTime.Now;
            }

            return color;
        }
    }
}
