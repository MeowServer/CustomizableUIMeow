namespace CustomizableUIMeow.Parser.ConditionParser.Respawn
{
    public class RespawnCondition
    {
        [ConditionParser("REIsRespawning")]
        public bool IsRespawning() => Exiled.API.Features.Respawn.IsSpawning;
    }
}
