using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using CustomizableUIMeow.Parser;
using CustomizableUIMeow.Utilities;
using CustomizableUIMeow.Model.ConfigClass;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using System.IO;

// * V1.0.0
// *     Separate from HintServiceMeow and add new features
// * V2.0.0 Remake

namespace CustomizableUIMeow
{
    internal class Plugin : Plugin<PluginConfig, PluginTranslation>
    {
        public override string Name => "CustomizableUIMeow";
        public override string Author => "MeowServer";
        public override Version Version => new Version(2, 0, 0);

        public override PluginPriority Priority => PluginPriority.Last;

        public static Plugin Instance;

        public override void OnEnabled()
        {
            Instance = this;
            PluginConfig.Instance = Config;
            PluginTranslation.Instance = Translation;

            FileReader.InitializeFile();

            ConditionParserLoader.Instance = new ConditionParserLoader();
            TagParserLoader.Instance = new TagParserLoader();

            TemplateLoader.Instance = new TemplateLoader();

            Exiled.Events.Handlers.Player.Verified += EventHandler.OnVerified;
            Exiled.Events.Handlers.Player.Left += EventHandler.OnLeft;
            Exiled.Events.Handlers.Player.ChangingRole += EventHandler.OnChangingRole;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            PluginConfig.Instance = null;
            PluginTranslation.Instance = null;

            ConditionParserLoader.Instance = null;
            TagParserLoader.Instance = null;

            TemplateLoader.Instance = null;

            Exiled.Events.Handlers.Player.Verified -= EventHandler.OnVerified;
            Exiled.Events.Handlers.Player.Left -= EventHandler.OnLeft;
            Exiled.Events.Handlers.Player.ChangingRole -= EventHandler.OnChangingRole;

            base.OnDisabled();
        }

        public override void OnReloaded()
        {
            DisplayManager.DisplayManagers.Clear();

            foreach(Player player in Player.List)
            {
                DisplayManager.GetOrCreate(player).SetTemplate();
            }

            base.OnReloaded();
        }
    }
}
