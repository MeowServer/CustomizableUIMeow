using Exiled.API.Enums;
using PlayerRoles;
using Respawning;
using System;

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

        public static string GetName(WarheadStatus warheadStatus)
        {
            if (PluginTranslation.WarheadStatusDictionary.TryGetValue(warheadStatus, out string name))
            {
                return name;
            }

            return null;
        }

        public static string GetName(WaveQueueState scp079Lvl)
        {
            if (PluginTranslation.WaveQueueStateDictionary.TryGetValue(scp079Lvl, out string name))
            {
                return name;
            }

            return null;
        }

        public static string GetName(SpawnableFaction spawnableFaction)
        {
            if (PluginTranslation.SpawnableFactionDictionary.TryGetValue(spawnableFaction, out string name))
            {
                return name;
            }

            return null;
        }
    }
}
