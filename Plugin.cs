using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using CustomizableUIMeow.Parser;
using CustomizableUIMeow.Utilities;
using CustomizableUIMeow.Model.ConfigClass;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using System.IO;
using CustomizableUIMeow.Utilities.UI;

// * V1.0.0
// *     Separate from HintServiceMeow and add new features
// * V2.0.0 Remake
// * V2.0.1 Bug Fixing
// *    Fixing the bug that the plugin throw null reference error when the player leave
// * V2.0.2 Minor changes
// *    Add API for other plugins to register their own tag parser and condition
// *    Add Data Recorder tags for player kill count and death count
// * V2.0.3 Bug Fixing
// *    Fix the bug that cause API not working properly
// * V2.0.4
// *    Add randomize in CustomHints tag
// * V2.0.5
// *    Add new tags for player's ID

namespace CustomizableUIMeow
{
    internal class Plugin : Plugin<PluginConfig, PluginTranslation>
    {
        public override string Name => "CustomizableUIMeow";
        public override string Author => "MeowServer";
        public override Version Version => new Version(2, 0, 5);

        public override PluginPriority Priority => PluginPriority.Default;

        public static Plugin Instance;

        public override void OnEnabled()
        {
            Instance = this;
            PluginConfig.Instance = Config;
            PluginTranslation.Instance = Translation;

            FileReader.InitializeFile();

            //UI
            BoolExpressionParser.Instance = new BoolExpressionParser();
            ConditionParserLoader.Instance = new ConditionParserLoader();
            TagParserLoader.Instance = new TagParserLoader();
            TemplateLoader.Instance = new TemplateLoader();

            Exiled.Events.Handlers.Player.Verified += EventHandler.OnVerified;
            Exiled.Events.Handlers.Player.Left += EventHandler.OnLeft;
            Exiled.Events.Handlers.Player.ChangingRole += EventHandler.OnChangingRole;

            //Data Recorder
            Utilities.DataRecorder.EventHandler.BindEvent();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            PluginConfig.Instance = null;
            PluginTranslation.Instance = null;

            //UI
            BoolExpressionParser.Instance = null;
            ConditionParserLoader.Instance = null;
            TagParserLoader.Instance = null;
            TemplateLoader.Instance = null;

            Exiled.Events.Handlers.Player.Verified -= EventHandler.OnVerified;
            Exiled.Events.Handlers.Player.Left -= EventHandler.OnLeft;
            Exiled.Events.Handlers.Player.ChangingRole -= EventHandler.OnChangingRole;

            //Data Recorder
            Utilities.DataRecorder.EventHandler.UnbindEvent();

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
