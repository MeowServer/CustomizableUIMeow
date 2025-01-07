using System;
using System.ComponentModel;
using HintServiceMeow.Core.Enum;

namespace CustomizableUIMeow.Model.ConfigClass
{
    [Serializable]
    public class ElementConfig
    {
        public string Name { get; set; } = "Your element name";

        public float XCoordinate { get; set; } = 0;

        public float YCoordinate { get; set; } = 700;

        public HintAlignment Alignment { get; set; } = HintAlignment.Center;

        public int Size { get; set; } = 20;

        public string Text = "Hello, World. Round had been elapsed for [RElapsedTime]";

        [Description("Fastest, Fast, Normal, Slow, UnSync")]
        public HintSyncSpeed UpdateRate { get; set; } = HintSyncSpeed.Normal;
    }
}
