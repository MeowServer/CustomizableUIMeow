using CustomizableUIMeow.Config;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableUIMeow.UITemplates
{
    internal class CustomSCPTemplate : SCPTemplate
    {
        public override PlayerUITemplateType type { get; } = PlayerUITemplateType.CustomSCP;

        public CustomSCPTemplate(Player player) : base(player)
        {
        }

        protected override void UpdateTopBar()
        {
            string template = UIPluginConfig.instance.CustomSCPTemplate.TopBar;

            TopBar.message = TemplateCommonTools.GetContent(template, player);
            TopBar.hide = false;
        }

        protected override void UpdateBottomBar()
        {
            string template = UIPluginConfig.instance.CustomSCPTemplate.BottomBar;

            BottomBar.message = TemplateCommonTools.GetContent(template, player);
            BottomBar.hide = false;
        }
    }

    internal class CustomHumanTemplate : GeneralHumanTemplate
    {
        public override PlayerUITemplateType type { get; } = PlayerUITemplateType.CustomHuman;

        public CustomHumanTemplate(Player player) : base(player)
        {
        }

        protected override void UpdateTopBar()
        {
            string template = UIPluginConfig.instance.CustomHumanTemplate.TopBar;

            TopBar.message = TemplateCommonTools.GetContent(template, player);
            TopBar.hide = false;
        }

        protected override void UpdateBottomBar()
        {
            string template = UIPluginConfig.instance.CustomHumanTemplate.BottomBar;

            BottomBar.message = TemplateCommonTools.GetContent(template, player);
            BottomBar.hide = false;
        }
    }
}
