using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using CustomizableUIMeow.Model.ConfigClass;

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
                InstallExampleUI();
            }
            else
            {
                foreach (var type in Enum.GetValues(typeof(FileType)))
                {
                    var path = Path.Combine(FilePath, type.ToString());

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                }
            }
        }

        private static void InstallExampleUI()
        {

        }
    }
}
