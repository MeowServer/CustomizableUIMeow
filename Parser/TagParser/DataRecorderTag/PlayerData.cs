using CustomizableUIMeow.Utilities.DataRecorder;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomizableUIMeow.Parser.TagParser.TagParserUtilities;

namespace CustomizableUIMeow.Parser.TagParser.DataRecorderTag
{
    public class PlayerData
    {
        [TagParser("PDKillCount")]
        public object KillCount(TagParserParameter parameter)
        {
            if(parameter.Player?.UserId == null)
                return 0;

            if (parameter.Arguments.TryDequeue(out string arg1))
            {
                if (arg1.ToLower() == "AfterRevive".ToLower())
                {
                    return PlayerRecorder.GetOrCreate(parameter.Player).KillCountAfterRevive;
                }

                if(RoleTypeGetter.TryGetRoles(arg1, out var roles))
                {
                    var result = 0;

                    if (parameter.Arguments.TryDequeue(out string arg2) && arg2.ToLower() == "AfterRevive".ToLower())
                    {
                        foreach (var role in roles)
                        {
                            if(PlayerRecorder.GetOrCreate(parameter.Player).RoleKillCountAfterRevive.TryGetValue(role, out var count))
                            {
                                result += count;
                            }
                        }
                    }
                    else
                    {
                        foreach (var role in roles)
                        {
                            if(PlayerRecorder.GetOrCreate(parameter.Player).RoleKillCount.TryGetValue(role, out var count))
                            {
                                result += count;
                            }
                        }
                    }

                    return result;
                    
                }
            }

            return PlayerRecorder.GetOrCreate(parameter.Player).KillCount;
        }

        [TagParser("PDDeathCount")]
        public object DeathCount(TagParserParameter parameter)
        {
            if (parameter.Player?.UserId == null)
                return 0;

            if (parameter.Arguments.TryDequeue(out var arg1))
            {
                if(RoleTypeGetter.TryGetRoles(arg1, out var roles))
                {
                    var result = 0;

                    if (parameter.Arguments.TryDequeue(out var arg2) && arg2 == "AsRole")
                    {
                        foreach (var role in roles)
                        {
                            if(PlayerRecorder.GetOrCreate(parameter.Player).DeathCountAsRole.TryGetValue(role, out var count))
                            {
                                result += count;
                            }
                        }
                    }
                    else
                    {
                        foreach (var role in roles)
                        {
                            if(PlayerRecorder.GetOrCreate(parameter.Player).RoleDeathCount.TryGetValue(role, out var count))
                            {
                                result += count;
                            }
                        }
                    }

                    return result;
                }
            }

            return PlayerRecorder.GetOrCreate(parameter.Player).DeathCount;
        }
    }
}
