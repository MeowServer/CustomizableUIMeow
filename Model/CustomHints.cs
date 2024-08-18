using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableUIMeow.Model
{
    public class CustomHints
    {
        public string TagName { get; set; } = "Your Custom Tag Name";

        public float SwitchInterval { get; set; } = 5f;

        public int LastIndex { get; set; } = 0;
        public DateTime NextUpdate { get; set; } = DateTime.MinValue;

        public List<string> TagContent { get; set; } = new List<string>()
        {
            "Your Custom Tag Content",
            "Some other content"
        };

        public bool Randomize { get; set; } = false;

        public CustomHints() { }
    }
}
