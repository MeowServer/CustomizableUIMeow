using System;
using System.Linq;
using Exiled.API.Features;
using Exiled.API.Enums;
using CustomizableUIMeow.Parser.TagParser.TagParserUtilities;

namespace CustomizableUIMeow.Parser.TagParser.CountTag
{
    public class Counter
    {
        [TagParser("Count")]
        public string Count(TagParserParameter parameter)
        {
            if (!parameter.Arguments.TryDequeue(out var arg))
                return null;

            //Get native enum count
            if (RoleTypeGetter.TryGetRoles(arg, out var roleTypes))
            {
                var roleCount = 0;

                foreach (var roleType in roleTypes)
                {
                    roleCount += Player.Get(roleType).Count();
                }

                return roleCount.ToString();
            }
               

            if (Enum.TryParse(arg, true, out AmmoType ammoType))
                return parameter.Player.GetAmmo(ammoType).ToString();

            if (Enum.TryParse(arg, true, out ItemType itemType))
                return parameter.Player.Items.Count(x => x.Type == itemType).ToString();

            //Generator count
            switch (arg.ToLower())
            {
                case "generator":
                    return Generator.List.Count.ToString();
                case "engagedgenerator":
                    return Generator.List.Count(x => x.State == GeneratorState.Engaged).ToString();
                case "notengagedgenerator":
                    return Generator.List.Count(x => x.State != GeneratorState.Engaged).ToString();
            }

            //Teammate tag
            switch (arg.ToLower())
            {
                case "teammate":
                    return Player.Get(parameter.Player.Role.Team).Count().ToString();
                case "sideteammate":
                    return Player.Get(parameter.Player.Role.Side).Count().ToString();
            }

            return null;
        }
    }
}
