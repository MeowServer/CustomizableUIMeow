using Exiled.API.Interfaces;
using HintServiceMeow.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableUIMeow.Config
{
    public class UIPluginConfig : IConfig
    {
        internal static UIPluginConfig instance;

        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("The config for general names")]
        public GeneralConfig GeneralConfig { get; set; } = new GeneralConfig();

        [Description("The config for PlayerUITools, will affect multiple templates")]
        public PlayerUIToolsConfig PlayerUIToolsConfig { get; private set; } = new PlayerUIToolsConfig();

        [Description("The config for general human tempalte")]
        public GeneralHumanTemplateConfig GeneralHumanTemplateConfig { get; private set; } = new GeneralHumanTemplateConfig();

        [Description("The config for scp tempalte")]
        public SCPTemplateConfig ScpTemplateConfig { get; private set; } = new SCPTemplateConfig();

        [Description("The config for custom human tempalte")]
        public CustomHumanTemplateConfig CustomHumanTemplate { get; private set; } = new CustomHumanTemplateConfig();

        [Description("The config for custom scp tempalte")]
        public CustomSCPTemplateConfig CustomSCPTemplate { get; private set; } = new CustomSCPTemplateConfig();

        [Description("The config for spectator tempalte")]
        public SpectatorTemplateConfig SpectatorTemplateConfig { get; private set; } = new SpectatorTemplateConfig();
    }
}
