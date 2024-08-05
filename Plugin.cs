using CustomizableUIMeow.Config;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using HarmonyLib;
using HintServiceMeow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableUIMeow
{
    class Plugin : Plugin<UIPluginConfig>
    {
        public override string Name => "CustomizableUIMeow";
        public override string Author => "MeowServerOwner";
        public override Version Version => new Version(1, 0, 0);

        public override PluginPriority Priority => PluginPriority.Default;

        public static Plugin instance;

        public override void OnEnabled()
        {
            if(Exiled.Loader.Loader.Plugins.First(x => x.Name == "HintServiceMeow").Version < new Version(4, 0, 0))
            {
                Log.Error("To load CustomizableUIMeow, HintServiceMeow's version must be higher or equal to 3.3.0.");
                return;
            }

            instance = this;
            UIPluginConfig.instance = Config;

            HintServiceMeow.EventHandler.NewPlayer += OnPlayerDisplayCreated;
            Exiled.Events.Handlers.Player.Left += OnLeft;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            instance = null;
            UIPluginConfig.instance = null;

            HintServiceMeow.EventHandler.NewPlayer -= OnPlayerDisplayCreated;
            Exiled.Events.Handlers.Player.Left -= OnLeft;

            base.OnDisabled();
        }

        // Create PlayerDisplay and PlayerUI for the new player
        private static void OnPlayerDisplayCreated(PlayerDisplay pd)
        {
            new TemplateLoader(pd.player);
        }

        private static void OnLeft(LeftEventArgs ev)
        {
            TemplateLoader.RemoveTemplateLoader(ev.Player);
        }
    }
}
