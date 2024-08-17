using CustomizableUIMeow.Utilities.UI;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CustomizableUIMeow.API.Features
{
    public static class TagParser
    {
        /// <summary>
        /// Register a tag parser
        /// </summary>
        public static void RegisterTagParserProvider(string name, Func<object> parser)
        {
            var pluginName = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .First(x => x.BaseType == typeof(Plugin))
                .Name;

            Log.Info($"Registering tag parser from {pluginName}: {name}");
            TagParserLoader.Instance.RegisterTagParser(name, parameter => parser());
        }

        /// <summary>
        /// Register a tag parser
        /// </summary>
        public static void RegisterTagParserProvider(string name, Func<Dictionary<string, object>, object> parser)
        {
            var pluginName = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .First(x => x.BaseType == typeof(Plugin))
                .Name;

            Log.Info($"Registering tag parser from {pluginName}: {name}");
            TagParserLoader.Instance.RegisterTagParser(name, parameter => parser(parameter.ToDictionary()));
        }

        /// <summary>
        /// Register a tag parser
        /// </summary>
        public static void RegisterTagParserProvider(string name, Func<dynamic, object> parser)
        {
            var pluginName = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .First(x => x.BaseType == typeof(Plugin))
                .Name;

            Log.Info($"Registering tag parser from {pluginName}: {name}");
            TagParserLoader.Instance.RegisterTagParser(name, parser);
        }
    }
}
