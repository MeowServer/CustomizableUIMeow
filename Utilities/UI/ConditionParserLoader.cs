using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CustomizableUIMeow.Parser.ConditionParser;
using Exiled.API.Features;

namespace CustomizableUIMeow.Utilities.UI
{
    public class ConditionParserLoader
    {
        public static ConditionParserLoader Instance;

        private readonly Dictionary<string, ConditionParserDelegate> _variables = new Dictionary<string, ConditionParserDelegate>();

        public ConditionParserLoader()
        {
            RegisterAllConditionParser();
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
                    RegisterConditionParser(instance);
                }
            }

            Log.Info($"Registered {_variables.Count} Conditions");
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
                    if (parameters.Length == 1 && parameters[0].ParameterType == typeof(ConditionParserParameter) && method.ReturnType == typeof(bool))
                    {
                        var delegateInstance = (ConditionParserDelegate)Delegate.CreateDelegate(typeof(ConditionParserDelegate), provider, method);
                        _variables[attribute.ConditionName.ToLower().Trim()] = delegateInstance;
                    }
                    else if (parameters.Length == 0 && method.ReturnType == typeof(bool))
                    {
                        var delegateInstance = (Func<bool>)Delegate.CreateDelegate(typeof(Func<bool>), provider, method);
                        _variables[attribute.ConditionName.ToLower().Trim()] = parameter => delegateInstance.Invoke();
                    }
                    else
                    {
                        Log.Error($"Method {method.Name} in {provider.GetType().Name} does not match the expected signature.");
                    }
                }
            }
        }

        public void RegisterConditionParser(string conditionName, ConditionParserDelegate parser)
        {
            _variables[conditionName.ToLower().Trim()] = parser;
        }

        public bool TryGetCondition(string conditionStr, out ConditionParserDelegate condition)
        {
            return _variables.TryGetValue(conditionStr.ToLower().Trim(), out condition);
        }

        public ConditionParserDelegate ParseBoolExpression(string conditionStr)
        {
            return BoolExpressionParser.Instance.Evaluate(conditionStr);
        }


        //public Func<bool> GetCondition(string conditionStr)
        //{
        //    return () => _expressionParser.Evaluate(conditionStr);
        //}
    }
}
