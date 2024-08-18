using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using CustomizableUIMeow.Parser.SimpleTag.TagParser;
using Exiled.API.Features;

namespace CustomizableUIMeow.Parser
{
    /// <summary>
    /// Used to load parser and parse the tags in text
    /// </summary>
    public class ParserLoader
    {
        public static ParserLoader Instance = new ParserLoader();

        private readonly List<object> parserProviderInstances = new List<object>();
        private readonly Dictionary<string, Func<TagParserParameter, string>> tagParserDictionary = new Dictionary<string, Func<TagParserParameter, string>>();

        private readonly Regex regex = new Regex(@"\[(.*?)\]", RegexOptions.Compiled);

        public void RegisterAllTagProviders()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                if (type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic)
                    .Any(m => m.GetCustomAttribute<TagParserAttribute>() != null))
                {
                    var instance = Activator.CreateInstance(type);
                    parserProviderInstances.Add(instance);
                    RegisterTagProviders(instance);
                }
            }
        }

        private void RegisterTagProviders(object provider)
        {
            var methods = provider.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(m => m.GetCustomAttribute<TagParserAttribute>() != null);

            foreach (var method in methods)
            {
                var attribute = method.GetCustomAttribute<TagParserAttribute>();
                if (attribute != null)
                {
                    var parameters = method.GetParameters();
                    if (parameters.Length == 1 && parameters[0].ParameterType == typeof(TagParserParameter) && method.ReturnType == typeof(string))
                    {
                        var delegateInstance = (Func<TagParserParameter, string>)Delegate.CreateDelegate(typeof(Func<TagParserParameter, string>), provider, method);
                        tagParserDictionary[attribute.TagName] = delegateInstance;
                    }
                    else
                    {
                        Console.WriteLine($"Method {method.Name} in {provider.GetType().Name} does not match the expected signature.");
                    }
                }
            }
        }

        public string ReplaceTags(string rawText, Player player)
        {
            return regex.Replace(rawText, match =>
            {
                var tagContent = match.Groups[1].Value;
                var parts = tagContent.Split(':');
                var tagName = parts[0];
                var args = parts.Skip(1).ToArray();
                var parameter = new TagParserParameter(player, args);

                if (tagParserDictionary.TryGetValue(tagName, out var valueProvider))
                {
                    try
                    {
                        return valueProvider(parameter);
                    }
                    catch(Exception e)
                    {
                        Log.Error($"Error while parsing tag {tagName}: {e}");
                    }
                }

                return match.Value;
            });
        }
    }
}
