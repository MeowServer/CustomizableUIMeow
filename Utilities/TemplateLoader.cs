using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomizableUIMeow.Model;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CustomizableUIMeow.Utilities
{
    /// <summary>
    /// Used to load UIs from files
    /// </summary>
    public class TemplateLoader
    {
        public static readonly TemplateLoader Instance = new TemplateLoader();

        public IReadOnlyList<Element> ElementList { get; private set; }
        public IReadOnlyList<UITemplate> TemplateList { get; private set; }

        public void LoadAllFile()
        {
            ElementList = LoadElements().AsReadOnly();
            TemplateList = LoadTemplates().AsReadOnly();
        }

        public List<Element> LoadElements()
        {
            var filePath = PluginConfig.Instance.FilePath;
            var elementPath = Path.Combine(filePath, "Elements");

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            if (!Directory.Exists(elementPath))
            {
                InitializeElementFile(elementPath);
            }

            List<Element> elementList = new List<Element>();

            foreach (var directory in Directory.GetFiles(elementPath))
            {
                if(!directory.EndsWith("yml") && !directory.EndsWith("yaml"))
                    continue;

                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                var file = File.ReadAllText(directory);
                var element = deserializer.Deserialize<Element>(file);
                elementList.Add(element);
            }

            return elementList;
        }

        public List<UITemplate> LoadTemplates()
        {
            var filePath = PluginConfig.Instance.FilePath;
            var templatePath = Path.Combine(filePath, "Templates");

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            if (!Directory.Exists(filePath) || !Directory.Exists(templatePath))
            {
                InitializeTemplateFile(templatePath);
            }

            List<UITemplate> templateList = new List<UITemplate>();

            foreach (var directory in Directory.GetFiles(templatePath))
            {
                if (!directory.EndsWith("yml") && !directory.EndsWith("yaml"))
                    continue;

                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                var file = File.ReadAllText(directory);
                var template = deserializer.Deserialize<UITemplate>(file);
                templateList.Add(template);
            }

            return templateList;
        }

        private void InitializeElementFile(string path)
        {
            //Create path
            Directory.CreateDirectory(path);

            //Create example
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var elementExamplePath = Path.Combine(path, "ExampleElement.yml");
            var exampleElement = serializer.Serialize(new Element());

            File.WriteAllText(elementExamplePath, exampleElement);
        }

        private void InitializeTemplateFile(string path)
        {
            //Create path
            Directory.CreateDirectory(path);

            //Create example
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var elementExamplePath = Path.Combine(path, "ExampleTemplate.yml");
            var exampleElement = serializer.Serialize(new UITemplate());

            File.WriteAllText(elementExamplePath, exampleElement);

        }
    }
}
