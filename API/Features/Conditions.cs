using CustomizableUIMeow.Parser;
using CustomizableUIMeow.Parser.ConditionParser;
using CustomizableUIMeow.Utilities.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using static Org.BouncyCastle.Crypto.Digests.SkeinEngine;
using System.Reflection;

namespace CustomizableUIMeow.API.Features
{
    public static class Conditions
    {
        /// <summary>
        /// Register a condition
        /// </summary>
        public static void RegisterCondition(string name, Func<bool> condition)
        {
            var pluginName = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .First(x => x.BaseType == typeof(Plugin))
                .Name;

            Log.Info($"Registering condition from {pluginName}: {name}");
            ConditionParserLoader.Instance.RegisterConditionParser(name, parameter => condition());
        }

        /// <summary>
        /// Register a condition
        /// </summary>
        public static void RegisterCondition(string name, Func<Dictionary<string, object>, bool> condition)
        {
            var pluginName = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .First(x => x.BaseType == typeof(Plugin))
                .Name;

            Log.Info($"Registering condition from {pluginName}: {name}");
            ConditionParserLoader.Instance.RegisterConditionParser(name, parameter => condition(parameter.ToDictionary()));
        }

        /// <summary>
        /// Register a condition
        /// </summary>
        public static void RegisterCondition(string name, Func<dynamic, bool> condition)
        {
            var pluginName = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .First(x => x.BaseType == typeof(Plugin))
                .Name;

            Log.Info($"Registering condition from {pluginName}: {name}");
            ConditionParserLoader.Instance.RegisterConditionParser(name, parameter => condition(parameter));
        }
    }
}
