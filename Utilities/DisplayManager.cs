using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomizableUIMeow.Model;
using CustomizableUIMeow.Parser;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using HintServiceMeow.Core.Extension;
using HintServiceMeow.Core.Models.Hints;
using HintServiceMeow.Core.Utilities;
using Hint = HintServiceMeow.Core.Models.Hints.Hint;

namespace CustomizableUIMeow.Utilities
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

            return manager??new DisplayManager(player);
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

            foreach (var elementName in template.Elements)
            {
                var element = TemplateLoader.Instance.ElementList
                    .FirstOrDefault(x => x.Name == elementName);

                if(element == null)
                    continue;

                hints.Add(new Hint
                {
                    Id = "CustomizableUI-" + element.Name,
                    XCoordinate = element.XCoordinate,
                    YCoordinate = element.YCoordinate,
                    Alignment = element.Alignment,
                    FontSize = element.Size,
                    AutoText = (AbstractHint.TextUpdateArg arg) =>
                    {
                        try
                        {
                            var text = ParserLoader.Instance.ReplaceTags(element.Text, Player);
                            return text;
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex);
                        }

                        return String.Empty;
                    }
                }); 
            }

            return hints;
        }
    }
}
