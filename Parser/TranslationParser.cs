using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableUIMeow.Parser
{
    // Used to translate the name of properties
    internal class TranslationParser
    {
        public static TranslationParser Instance;

        private readonly Dictionary<Type, Dictionary<object, string>> _nameTranslations = new Dictionary<Type, Dictionary<object, string>>();

        public TranslationParser()
        {
            PropertyInfo[] properties = PluginTranslation.Instance.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                // Getting the value of the property
                Dictionary<object, string> value = (Dictionary<object, string>)property.GetValue(PluginTranslation.Instance);
                Type type = value.GetType().GetGenericArguments().First();

                _nameTranslations.Add(type, value);
            }
        }

        public string GetTranslatedName(object rawProperty, Type type)
        {
            if(_nameTranslations.TryGetValue(type, out var translations) 
                && translations.TryGetValue(rawProperty, out var translatedName))
            {
                return translatedName;
            }

            return rawProperty.ToString();
        }
    }
}
