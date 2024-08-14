using CustomizableUIMeow.Parser.SimpleTag.TagParser;
using CustomizableUIMeow.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CustomizableUIMeow.Parser.ConditionParser;
using Exiled.API.Features;

namespace CustomizableUIMeow.Utilities
{
    public class ConditionParserLoader
    {
        public static ConditionParserLoader Instance;

        private readonly List<object> parserProviderInstances = new List<object>();
        private readonly Dictionary<string, Func<bool>> Variables = new Dictionary<string, Func<bool>>();

        private readonly BoolExpressionParser ExpressionParser;

        public ConditionParserLoader()
        {
            RegisterAllConditionParser();
            ExpressionParser = new BoolExpressionParser(Variables);
        }

        public void RegisterAllConditionParser()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                if (type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic)
                    .Any(m => m.GetCustomAttribute<ConditionParserAttribute>() != null))
                {
                    var instance = Activator.CreateInstance(type);
                    parserProviderInstances.Add(instance);
                    RegisterConditionParser(instance);
                }
            }
        }

        private void RegisterConditionParser(object provider)
        {
            var methods = provider.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(m => m.GetCustomAttribute<ConditionParserAttribute>() != null);

            foreach (var method in methods)
            {
                var attribute = method.GetCustomAttribute<ConditionParserAttribute>();
                if (attribute != null)
                {
                    var parameters = method.GetParameters();
                    if (parameters.Length == 0)
                    {
                        var delegateInstance = (Func<bool>)Delegate.CreateDelegate(typeof(Func<bool>), provider, method);
                        Variables[attribute.ConditionName.ToLower().Trim()] = delegateInstance;
                    }
                    else
                    {
                        Log.Error($"Method {method.Name} in {provider.GetType().Name} does not match the expected signature.");
                    }
                }
            }
        }

        public Func<bool> GetCondition(string conditionStr)
        {
            return () => ExpressionParser.Evaluate(conditionStr);
        }
    }
}
