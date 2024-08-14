using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableUIMeow.Parser
{
    public class BoolExpressionParser
    {
        private readonly Dictionary<string, Func<bool>> _variables;
        private int _position;
        private string _expression;

        public BoolExpressionParser(Dictionary<string, Func<bool>> variables)
        {
            _variables = variables;
        }

        public bool Evaluate(string expression)
        {
            _expression = expression.Replace(" ", "");
            _position = 0;

            return ParseOr();
        }

        private bool ParseOr()
        {
            bool left = ParseAnd();
            while (Match("||"))
            {
                left = left || ParseAnd();
            }
            return left;
        }

        private bool ParseAnd()
        {
            bool left = ParseUnary();
            while (Match("&&"))
            {
                left = left && ParseUnary();
            }
            return left;
        }

        private bool ParseUnary()
        {
            if (Match("!"))
            {
                return !ParseUnary();
            }
            return ParseVariable();
        }

        private bool ParseVariable()
        {
            string variable = "";
            while (_position < _expression.Length && char.IsLetter(_expression[_position]))
            {
                variable += _expression[_position];
                _position++;
            }

            if (_variables.TryGetValue(variable.ToLower().Trim(), out Func<bool> function))
            {
                return function.Invoke();
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
