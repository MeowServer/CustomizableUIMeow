using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CustomizableUIMeow.Model;
using Exiled.API.Features;
using YamlDotNet.Core.Tokens;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using static CustomizableUIMeow.Model.UITemplate;

namespace CustomizableUIMeow.Utilities
{
    /// <summary>
    /// Used to load UIs from files
    /// </summary>
    public class TemplateLoader
    {
        public static TemplateLoader Instance;

        public IReadOnlyList<Element> ElementList { get; private set; }
        public IReadOnlyList<UITemplate> TemplateList { get; private set; }

        public TemplateLoader()
        {
            ElementList = LoadElements().AsReadOnly();
            TemplateList = LoadTemplates().AsReadOnly();
        }

        public List<Element> LoadElements()
        {
            var elementList = new List<Element>();
            var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

            foreach (var file in FileReader.ReadFile(FileReader.FileType.Elements))
            {
                try
                {
                    var elementConfig = deserializer.Deserialize<ElementConfig>(file.Item2);

                    var element = new Element(
                        elementConfig.Name,
                        elementConfig.XCoordinate,
                        elementConfig.YCoordinate,
                        elementConfig.Alignment,
                        elementConfig.Size,
                        elementConfig.Text,
                        elementConfig.UpdateRate);

                    elementList.Add(element);
                }
                catch(Exception ex)
                {
                    Log.Error($"Error while parsing elements. File: {file.Item1} Exception: {ex}");
                }
            }

            return elementList;
        }

        public List<UITemplate> LoadTemplates()
        {
            var templateList = new List<UITemplate>();
            var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

            foreach (var file in FileReader.ReadFile(FileReader.FileType.Templates))
            {
                try
                {
                    var templateConfig = deserializer.Deserialize<UITemplateConfig>(file.Item2);

                    templateList.Add(ParseTemplateConfig(templateConfig));
                }
                catch(Exception ex)
                {
                    Log.Error($"Error while parsing templates. File: {file.Item1} Exception: {ex}");
                }
            }

            return templateList;
        }

        public UITemplate ParseTemplateConfig(UITemplateConfig config)
        {
            UITemplate result = new UITemplate();

            result.AppliedRole = new List<PlayerRoles.RoleTypeId>(config.AppliedRole);

            foreach (object obj in config.Elements)
            {
                try
                {
                    if (obj is string name)
                    {
                        var element = ElementList.FirstOrDefault(x => x.Name == name);
                        if (element != null)
                        {
                            result.Elements.Add(new ConditionalElement()
                            {
                                Element = element
                            });
                        }
                    }
                    else if (obj is Dictionary<object, object> dic)
                    {
                        foreach (var kvp in dic)
                            foreach (var elementName in kvp.Value as List<object>)
                            {
                                var element = ElementList.FirstOrDefault(x => x.Name == (string)elementName);
                                if (element != null)
                                {
                                    result.Elements.Add(new ConditionalElement()
                                    {
                                        Element = element,
                                        Condition = ConditionParserLoader.Instance.GetCondition((string)kvp.Key)
                                    });
                                }
                            }
                    }
                }
                catch(Exception ex)
                {
                    Log.Error($"Error while parsing elements when intializing the template: {ex}");
                }
            }

            return result;
        }
    }
}
