using CustomizableUIMeow.Parser.ConditionParser;
using CustomizableUIMeow.Utilities;
using CustomizableUIMeow.Utilities.UI;
using Exiled.API.Enums;
using Exiled.API.Features;
using System;

namespace CustomizableUIMeow
{
    internal class Plugin : Plugin<PluginConfig, PluginTranslation>
    {
        public override string Name => "CustomizableUIMeow";
        public override string Author => "MeowServer";
        public override Version Version => new Version(2, 1, 1);

        public override Version RequiredExiledVersion => new Version(9, 0, 0);

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

            foreach (Player player in Player.List)
            {
                DisplayManager.GetOrCreate(player).SetTemplate();
            }

            base.OnReloaded();
        }
    }
}
