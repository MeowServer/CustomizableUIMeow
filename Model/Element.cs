using HintServiceMeow.Core.Enum;

namespace CustomizableUIMeow.Model
{
    public class Element
    {
        public string Name { get; set; }

        public float XCoordinate { get; set; }
        public float YCoordinate { get; set; }
        public HintAlignment Alignment { get; set; }

        public int Size { get; set; }
        public string Text { get; set; }

        public HintSyncSpeed SyncSpeed { get; set; }

        public Element(string name, float xCoordinate, float yCoordinate, HintAlignment alignment, int size, string text, HintSyncSpeed syncSpeed)
        {
            this.Name = name;

            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.Alignment = alignment;

            this.Size = size;
            this.Text = text;

            this.SyncSpeed = syncSpeed;
        }
    }
}
