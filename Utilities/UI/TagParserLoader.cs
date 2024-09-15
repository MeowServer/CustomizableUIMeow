using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

using CustomizableUIMeow.Parser.TagParser;
using Exiled.API.Features;

namespace CustomizableUIMeow.Utilities.UI
{
    /// <summary>
    /// Used to load parser and parse the tags in text
    /// </summary>
    public class TagParserLoader
    {
        public static TagParserLoader Instance;

        private readonly List<object> parserProviderInstances = new List<object>();
        private readonly Dictionary<string, Func<TagParserParameter, object>> tagParserDictionary = new Dictionary<string, Func<TagParserParameter, object>>();

        private readonly Regex regex = new Regex(@"\[(.*?)\]", RegexOptions.Compiled);

        public TagParserLoader()
        {
            RegisterAllTagParser();
        }

        public void RegisterAllTagParser()
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
                    RegisterTagParser(instance);
                }
            }

            Log.Info($"Loaded {tagParserDictionary.Count} tag parsers.");
        }

        public void RegisterTagParser(string tagName, Func<TagParserParameter, object> parser)
        {
            tagParserDictionary[tagName.ToLower().Trim()] = parser;
        }

        private void RegisterTagParser(object provider)
        {
            var methods = provider.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(m => m.GetCustomAttribute<TagParserAttribute>() != null);

            foreach (var method in methods)
            {
                var attribute = method.GetCustomAttribute<TagParserAttribute>();
                if (attribute != null)
                {
                    var parameters = method.GetParameters();
                    if (parameters.Length == 1 && parameters[0].ParameterType == typeof(TagParserParameter) && (method.ReturnType == typeof(object) || method.ReturnType == typeof(string)))
                    {
                        var delegateInstance = (Func<TagParserParameter, object>)Delegate.CreateDelegate(typeof(Func<TagParserParameter, object>), provider, method);
                        tagParserDictionary[attribute.TagName.ToLower().Trim()] = delegateInstance;
                    }
                    else
                    {
                        Log.Error($"Method {method.Name} in {provider.GetType().Name} does not match the expected signature.");
                    }
                }
            }
        }

        public string ReplaceTags(string rawText, Player player)
        {
            return regex.Replace(rawText, match =>
            {
                var tagContent = match.Groups[1].Value;

                var parts = tagContent.Split('|');

                var tagName = parts[0];
                var args = new Queue<string>(parts.Skip(1));

                if (tagParserDictionary.TryGetValue(tagName.ToLower().Trim(), out var tagParser))
                {
                    try
                    {
                        return tagParser(new TagParserParameter(player, tagName, args))?.ToString()??string.Empty;
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
