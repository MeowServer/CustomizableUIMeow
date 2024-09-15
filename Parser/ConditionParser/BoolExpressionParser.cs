using CustomizableUIMeow.Parser.ConditionParser;
using CustomizableUIMeow.Utilities.UI;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Digests.SkeinEngine;

namespace CustomizableUIMeow.Parser
{
    public delegate bool ConditionParserDelegate(ConditionParserParameter parameter);

    public class BoolExpressionParser
    {
        public static BoolExpressionParser Instance { get; internal set; }

        private int _position;
        private string _expression;

        public ConditionParserDelegate Evaluate(string expression)
        {
            _expression = expression.Replace(" ", "");
            _position = 0;

            ConditionParserDelegate result = ParseOr();

            return result;
        }

        private ConditionParserDelegate ParseOr()
        {
            ConditionParserDelegate left = ParseAnd();
            while (Match("||"))
            {
                ConditionParserDelegate right = ParseAnd();

                left = parameter => left(parameter) || right(parameter);
            }
            return left;
        }

        private ConditionParserDelegate ParseAnd()
        {
            ConditionParserDelegate left = ParseUnary();
            while (Match("&&"))
            {
                ConditionParserDelegate right = ParseUnary();

                left = parameter => left(parameter) && right(parameter);
            }
            return left;
        }

        private ConditionParserDelegate ParseUnary()
        {
            if (Match("!"))
            {
                ConditionParserDelegate right = ParseUnary();

                return parameter => !right(parameter);
            }

            ConditionParserDelegate left = ParseVariable();

            return left;
        }

        private ConditionParserDelegate ParseVariable()
        {
            string variable = "";
            while (_position < _expression.Length && char.IsLetter(_expression[_position]))
            {
                variable += _expression[_position];
                _position++;
            }

            if (ConditionParserLoader.Instance.TryGetCondition(variable.ToLower().Trim(), out ConditionParserDelegate method))
            {
                return method;
            }

            throw new ArgumentException($"Unknown condition: {variable}");
        }

        private bool Match(string token)
        {
            if (_expression.Substring(_position).StartsWith(token))
            {
                _position += token.Length;
                return true;
            }

            return false;
        }
    }
}
