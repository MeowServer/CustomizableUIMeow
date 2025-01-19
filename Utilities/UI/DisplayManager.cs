using CustomizableUIMeow.Model;
using CustomizableUIMeow.Parser.ConditionParser;
using Exiled.API.Features;
using HintServiceMeow.Core.Extension;
using HintServiceMeow.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using Hint = HintServiceMeow.Core.Models.Hints.Hint;

namespace CustomizableUIMeow.Utilities.UI
{
    public class DisplayManager
    {
        public static HashSet<DisplayManager> DisplayManagers { get; } = new HashSet<DisplayManager>();

        public Player Player { get; }

        public List<UITemplate> Templates = new List<UITemplate>();

        public DisplayManager(Player player)
        {
            Player = player;
            DisplayManagers.Add(this);
        }

        public static DisplayManager GetOrCreate(Player player)
        {
            var manager = DisplayManagers.FirstOrDefault(x => x.Player == player);

            return manager ?? new DisplayManager(player);
        }

        public static void Destruct(Player player)
        {
            DisplayManagers.RemoveWhere(x => x.Player == player);
        }

        public void SetTemplate()
        {
            //Clear current template
            List<string> allElements = Templates
                .SelectMany(x => x.Elements)
                .Select(x => x.Element.Name)
                .ToList();

            foreach (var elementName in allElements)
            {
                Player.GetPlayerDisplay().RemoveHint("CustomizableUI-" + elementName);
            }

            Templates.Clear();

            //Apply new template
            Templates = TemplateLoader.Instance.TemplateList
                .Where(x => x.AppliedRole.Contains(Player.Role.Type))
                .ToList();

            foreach (var template in Templates)
            {
                PlayerDisplay.Get(Player).AddHint(GetHints(template));
            }
        }

        public List<Hint> GetHints(UITemplate template)
        {
            List<Hint> hints = new List<Hint>();

            foreach (var conditionalElement in template.Elements)
            {
                //Get element
                var element = conditionalElement.Element;

                var conditionArgument = new ConditionParserParameter(Player);

                //Create hint for element
                if (element != null)
                    hints.Add(new Hint
                    {
                        Id = "CustomizableUI-" + element.Name,
                        XCoordinate = element.XCoordinate,
                        YCoordinate = element.YCoordinate,
                        Alignment = element.Alignment,
                        FontSize = element.Size,
                        SyncSpeed = element.SyncSpeed,
                        AutoText = arg =>
                        {
                            try
                            {
                                //Check condition
                                if (conditionalElement.Condition.Invoke(conditionArgument))
                                    return TagParserLoader.Instance.ReplaceTags(element.Text, Player);
                            }
                            catch (Exception ex)
                            {
                                Log.Error(ex);
                            }

                            return null;
                        }
                    });
            }

            return hints;
        }
    }
}
