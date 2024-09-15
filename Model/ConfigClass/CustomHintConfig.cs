using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableUIMeow.Model.ConfigClass
{
    public class CustomHintConfig
    {
        public string TagName { get; set; } = "Your Custom Tag Name";

        public float SwitchInterval { get; set; } = 5f;

        public bool Randomize { get; set; } = false;

        public List<string> TagContent { get; set; } = new List<string>()
        {
            "Your Custom Tag Content",
            "Some other content"
        };
    }
}
