using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableUIMeow.Parser.ConditionParser.Round
{
    internal class RoundCondition
    {
        [ConditionParser("RIsEnded")]
        public bool IsEnded() => Exiled.API.Features.Round.IsEnded;
    }
}
