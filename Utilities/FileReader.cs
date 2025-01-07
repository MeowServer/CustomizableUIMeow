using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CustomizableUIMeow.Model.ConfigClass;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
namespace CustomizableUIMeow.Utilities
{
    public static class FileReader
    {
        private static string FilePath => PluginConfig.Instance.FilePath;

        public enum FileType
        {
            Templates,
            Elements,
            CustomTags
        }

        // Return a list of tuple containing the file name and the content of the file
        public static IEnumerable<Tuple<string, string>> ReadFile(FileType type)
        {
            var path = Path.Combine(FilePath, type.ToString());

            return Directory
                .GetFiles(path, "*.yml", SearchOption.AllDirectories)
                .Select(x => Tuple.Create(x, File.ReadAllText(x)));
        }

        public static void InitializeFile()
        {
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            //Templates
            var path = Path.Combine(FilePath, FileType.Templates.ToString());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                File.WriteAllText(Path.Combine(path, "YourTemplate.yml"), serializer.Serialize(new UITemplateConfig()));
            }

            //Elements
            path = Path.Combine(FilePath, FileType.Elements.ToString());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                File.WriteAllText(Path.Combine(path, "YourElement.yml"), serializer.Serialize(new ElementConfig()));
            }

            //CustomTags
            path = Path.Combine(FilePath, FileType.CustomTags.ToString());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                File.WriteAllText(Path.Combine(path, "YourCustomTag.yml"), serializer.Serialize(new CustomHintConfig()));
            }
        }
    }
}
