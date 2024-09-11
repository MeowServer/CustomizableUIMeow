using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableUIMeow.Parser
{
    internal class ArgumentParser
    {
        public static ArgumentParser Instance;

        //Since there's limited amount of argument type, we can cache the result without expiration time
        private readonly Dictionary<ValueTuple<Type, string>, object> _argumentCache = new Dictionary<ValueTuple<Type, string>, object>();

        public T ConvertArgument<T>(string value)
        {
            Type targetType = typeof(T);

            if(_argumentCache.TryGetValue(ValueTuple.Create(targetType, value), out object result))
            {
                return (T)result;
            }

            if (targetType.IsEnum)
            {
                result = Enum.Parse(targetType, value);

                _argumentCache[ValueTuple.Create(targetType, value)] = result;
            }
            else
            {
                try
                {
                    result = Convert.ChangeType(value, targetType);

                    _argumentCache[ValueTuple.Create(targetType, value)] = result;
                }
                catch (InvalidCastException)
                {
                    throw new NotSupportedException($"Cannot convert value '{value}' to type {targetType.Name}");
                }
            }

            return (T)result;
        }
    }
}
