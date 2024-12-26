using Exiled.API.Enums;
using Exiled.API.Interfaces;
using PlayerRoles;
using Respawning;
using System.Collections.Generic;
using System.ComponentModel;

namespace CustomizableUIMeow
{
    internal class PluginTranslation : ITranslation
    {
        public static PluginTranslation Instance;

        [Description("PluginTranslation of different role types")]
        public Dictionary<RoleTypeId, string> RoleName { get; private set; } = new Dictionary<RoleTypeId, string>()
        {
            { RoleTypeId.None, "None"},
            { RoleTypeId.Scp173, "Scp173"},
            { RoleTypeId.ClassD, "Class D"},
            { RoleTypeId.Spectator, "Spectator"},
            { RoleTypeId.Scp106, "Scp106"},
            { RoleTypeId.NtfSpecialist, "Ntf Specialist"},
            { RoleTypeId.Scp049, "Scp049"},
            { RoleTypeId.Scientist, "Scientist"},
            { RoleTypeId.Scp079, "Scp079"},
            { RoleTypeId.ChaosConscript, "Chaos Conscript"},
            { RoleTypeId.Scp096, "Scp096"},
            { RoleTypeId.Scp0492, "Scp049-2"},
            { RoleTypeId.NtfSergeant, "Ntf Sergeant"},
            { RoleTypeId.NtfCaptain, "Ntf Captain"},
            { RoleTypeId.NtfPrivate, "Ntf Private"},
            { RoleTypeId.Tutorial, "Tutorial"},
            { RoleTypeId.FacilityGuard, "Facility Guard"},
            { RoleTypeId.Scp939, "Scp939"},
            { RoleTypeId.CustomRole, "CustomRole"},
            { RoleTypeId.ChaosRifleman, "Chaos Rifleman"},
            { RoleTypeId.ChaosMarauder, "Chaos Marauder"},
            { RoleTypeId.ChaosRepressor, "Chaos Repressor"},
            { RoleTypeId.Overwatch, "Overwatch"},
            { RoleTypeId.Filmmaker, "Filmmaker"},
            { RoleTypeId.Scp3114, "Scp3114"},
        };

        [Description("PluginTranslation of different team types")]
        public Dictionary<Team, string> TeamName { get; private set; } = new Dictionary<Team, string>()
        {
            { Team.ChaosInsurgency, "Chaos Insurgency" },
            { Team.ClassD, "Class D" },
            { Team.Dead, "Dead" },
            { Team.FoundationForces, "Foundation Force" },
            { Team.OtherAlive, "Other Alive" },
            { Team.Scientists, "Scientist" },
            { Team.SCPs, "SCP"},
        };

        [Description("PluginTranslation of different leading team types")]
        public Dictionary<LeadingTeam, string> LeadingTeamName { get; private set; } = new Dictionary<LeadingTeam, string>()
        {
            { LeadingTeam.FacilityForces, "Facility Force" },
            { LeadingTeam.ChaosInsurgency, "Chaos Insurgency" },
            { LeadingTeam.Anomalies, "SCP" },
            {LeadingTeam.Draw, "Draw" }
        };

        [Description("PluginTranslation of different item types")]
        public Dictionary<ItemType, string> ItemName { get; private set; } = new Dictionary<ItemType, string>()
        {
            {ItemType.KeycardJanitor,"Janitor Keycard" },
            {ItemType.KeycardScientist,"Scientist Keycard" },
            {ItemType.KeycardResearchCoordinator,"Research Coordinator Keycard" },
            {ItemType.KeycardZoneManager,"Zone Manager Keycard" },
            {ItemType.KeycardGuard,"Guard Keycard"},
            {ItemType.KeycardMTFOperative,"MTF Operative Keycard" },
            {ItemType.KeycardMTFCaptain,"MTF Captain Keycard" },
            {ItemType.KeycardFacilityManager,"Facility Manager Keycard" },
            {ItemType.KeycardChaosInsurgency,"Chaos Insurgency Keycard" },
            {ItemType.KeycardO5,"O5 Keycard" },
            {ItemType.Radio,"Radio" },
            {ItemType.GunCOM15,"COM15" },
            {ItemType.Medkit,"Medkit" },
            {ItemType.Flashlight,"Flashlight" },
            {ItemType.MicroHID,"MicroHID" },
            {ItemType.SCP500,"SCP500" },
            {ItemType.SCP207,"SCP207" },
            {ItemType.Ammo12gauge,"12 Gauge Ammo" },
            {ItemType.GunE11SR,"E11SR" },
            {ItemType.GunCrossvec,"Crossvec" },
            {ItemType.Ammo556x45,"556x45 Ammo" },
            {ItemType.GunFSP9,"FSP9" },
            {ItemType.GunLogicer,"Logicer" },
            {ItemType.GrenadeHE,"HE Grenade" },
            {ItemType.GrenadeFlash,"Flash Grenade" },
            {ItemType.Ammo44cal,"44cal Ammo" },
            {ItemType.Ammo762x39,"762x39 Ammo" },
            {ItemType.Ammo9x19,"9x19 Ammo" },
            {ItemType.GunCOM18,"COM18" },
            {ItemType.SCP018,"SCP018" },
            {ItemType.SCP268,"SCP268" },
            {ItemType.Adrenaline,"Adrenaline" },
            {ItemType.Painkillers,"Pain Killers" },
            {ItemType.Coin,"Coin" },
            {ItemType.ArmorLight,"Light Armor" },
            {ItemType.ArmorCombat,"Combat Armor" },
            {ItemType.ArmorHeavy,"Heavy Armor" },
            {ItemType.GunRevolver,"Revolver" },
            {ItemType.GunAK,"AK" },
            {ItemType.GunShotgun,"Shotgun" },
            {ItemType.SCP330,"SCP330" },
            {ItemType.SCP2176,"SCP2176" },
            {ItemType.SCP244a,"SCP244a" },
            {ItemType.SCP244b,"SCP244b" },
            {ItemType.AntiSCP207,"Anti SCP207" }
        };

        [Description("PluginTranslation of different zone names")]
        public Dictionary<ZoneType, string> ZoneName { get; private set; } = new Dictionary<ZoneType, string>()
        {
            {ZoneType.LightContainment, "Light Containment" },
            {ZoneType.HeavyContainment, "Heavy Containment" },
            {ZoneType.Entrance, "Entrance" },
            {ZoneType.Surface, "Surface" },
            {ZoneType.Unspecified, "Unspecified" }
        };

        [Description("PluginTranslation of different respawnable role types")]
        public Dictionary<SpawnableTeamType, string> RespawnTeamDictionary { get; private set; } = new Dictionary<SpawnableTeamType, string>
        {
            {SpawnableTeamType.NineTailedFox, "<color=#0096FF>NTF</color>" },
            {SpawnableTeamType.ChaosInsurgency, "<color=#0D7D35>Chaos Insurgency</color>" },
            {SpawnableTeamType.None, "None" }
        };

        [Description("PluginTranslation of different warhead status")]
        public Dictionary<WarheadStatus, string> WarheadStatusDictionary { get; private set; } = new Dictionary<WarheadStatus, string>
        {
            {WarheadStatus.Armed, "<color=#d0652f>Ready</color>" },
            {WarheadStatus.NotArmed, "<color=#7fd827>Not Ready</color>" },
            {WarheadStatus.Detonated, "<color=#ce313f>Detonated</color>" },
            {WarheadStatus.InProgress, "<color=#d0652f>In Progress</color>" },
        };


    }
}
