using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableUIMeow.Parser.TagParser.TagParserUtilities
{
    public static class RoleTypeGetter
    {
        public static bool TryGetRoles(string rawArgument, out List<RoleTypeId> result)
        {
            var argument = rawArgument.Replace(" ", "").Split(',');

            result = new List<RoleTypeId>();
            foreach (var arg in argument)
            {
                if(Enum.TryParse(arg, true, out RoleTypeId roleType))
                {
                    result.Add(roleType);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
