using HintServiceMeow.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableUIMeow.Model
{
    public class Element
    {
        public string Name { get; set; } = "";

        public float XCoordinate { get; set; } = 0;
        public float YCoordinate { get; set; } = 700;
        public HintAlignment Alignment { get; set; } = HintAlignment.Center;

        public int Size { get; set; } = 20;
        public string Text = "";

        public HintSyncSpeed syncSpeed { get; set; }

        public Element(string name, float xCoordinate, float yCoordinate, HintAlignment alignment, int size, string text, HintSyncSpeed syncSpeed)
        {
            this.Name = name;

            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.Alignment = alignment;

            this.Size = size;
            this.Text = text;

            this.syncSpeed = syncSpeed;
        }
    }
}
