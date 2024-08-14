using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableUIMeow.Parser.ConditionParser.Respawn
{
    public class RespawnCondition
    {
        [ConditionParser("REIsRespawning")]
        public bool IsRespawning() => Exiled.API.Features.Respawn.IsSpawning;
    }
}
