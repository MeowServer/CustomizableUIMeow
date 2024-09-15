using System.ComponentModel;
using System.IO;

using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace CustomizableUIMeow
{
    internal class PluginConfig:IConfig
    {
        public static PluginConfig Instance;

        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("The path to the templates and elements file")]
        public string FilePath { get; set; } = Path.Combine(Paths.Configs, "UI Templates");
    }
}
