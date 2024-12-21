using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Enums;
using Exiled.API.Interfaces;
using Exiled.Events.EventArgs.Scp173;
using PlayerRoles;
using Respawning;

namespace CustomizableUIMeow.Parser.TagParser.ParserUtilities
{
    public static class NameTranslator
    {
        private static PluginTranslation PluginTranslation => Plugin.Instance.Translation;

        public static string GetName(RoleTypeId roleType)
        {
            if (PluginTranslation.RoleName.TryGetValue(roleType, out string name))
            {
                return name;
            }

            return null;
        }

        public static string GetName(Team teamType)
        {
            if (PluginTranslation.TeamName.TryGetValue(teamType, out string name))
            {
                return name;
            }

            return null;
        }

        public static string GetName(LeadingTeam leadingTeam)
        {
            if (PluginTranslation.LeadingTeamName.TryGetValue(leadingTeam, out string name))
            {
                return name;
            }

            return null;
        }

        public static string GetName(ItemType itemType)
        {
            if (PluginTranslation.ItemName.TryGetValue(itemType, out string name))
            {
                return name;
            }

            return null;
        }

        public static string GetName(AmmoType ammoType)
        {
            if (Enum.TryParse(ammoType.ToString(), out ItemType itemType))
            {
                return GetName(itemType);
            }

            return null;
        }

        public static string GetName(ZoneType zoneType)
        {
            if (PluginTranslation.ZoneName.TryGetValue(zoneType, out string name))
            {
                return name;
            }

            return null;
        }

        public static string GetName(SpawnableTeamType spawningTeamType)
        {
            //I have no idea yet. but this fixed is work for some reason.
            //TODO: Hope Fansh fix this.
            if (PluginTranslation.RespawnTeamDictionary.TryGetValue((Team)spawningTeamType, out string name))
            {
                return name;
            }

            return null;
        }

        public static string GetName(WarheadStatus warheadStatus)
        {
            if (PluginTranslation.WarheadStatusDictionary.TryGetValue(warheadStatus, out string name))
            {
                return name;
            }

            return null;
        }
    }
}
