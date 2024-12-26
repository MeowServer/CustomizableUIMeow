namespace CustomizableUIMeow.Parser.ConditionParser.Round
{
    internal class RoundCondition
    {
        [ConditionParser("RIsEnded")]
        public bool IsEnded() => Exiled.API.Features.Round.IsEnded;
    }
}
