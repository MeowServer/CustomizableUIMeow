using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using PlayerRoles;
using Utils.NonAllocLINQ;

namespace CustomizableUIMeow.Utilities.DataRecorder
{
    public class PlayerRecorder
    {
        private static Dictionary<string, PlayerRecorder> PlayerRecorders { get; } = new Dictionary<string, PlayerRecorder>();

        /// <summary>
        /// The total kill count
        /// </summary>
        public int KillCount { get; private set; }

        /// <summary>
        /// Kill count of killing a player that has specific role
        /// </summary>
        public Dictionary<RoleTypeId, int> RoleKillCount { get; } = new Dictionary<RoleTypeId, int>();

        /// <summary>
        /// Kill count of killing a player that has specific role since last revive
        /// </summary>
        public Dictionary<RoleTypeId, int> RoleKillCountAfterRevive { get; } = new Dictionary<RoleTypeId, int>();

        /// <summary>
        /// Kill count after last death
        /// </summary>
        public int KillCountAfterRevive { get; private set; }

        /// <summary>
        /// Total death count
        /// </summary>
        public int DeathCount;

        /// <summary>
        /// Count of being killed by some role
        /// </summary>
        public Dictionary<RoleTypeId, int> RoleDeathCount { get; } = new Dictionary<RoleTypeId, int>();

        /// <summary>
        /// Count of being killed as some role
        /// </summary>
        public Dictionary<RoleTypeId, int> DeathCountAsRole { get; } = new Dictionary<RoleTypeId, int>();

        private List<KillRecord> KillRecordList { get; } = new List<KillRecord>();
        private List<DeathRecord> DeathRecordList { get; } = new List<DeathRecord>();

        private PlayerRecorder(Player player)
        {
            PlayerRecorders.Add(player.UserId, this);

            foreach (RoleTypeId roleType in Enum.GetValues(typeof(RoleTypeId)))
            {
                RoleKillCount.Add(roleType, 0);
                RoleKillCountAfterRevive.Add(roleType, 0);

                RoleDeathCount.Add(roleType, 0);
                DeathCountAsRole.Add(roleType, 0);
            }
        }

        public static PlayerRecorder GetOrCreate(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));
            if (player.UserId == null)
                throw new ArgumentNullException(nameof(player.UserId));

            return PlayerRecorders.TryGetValue(player.UserId, out var recorder) ? recorder : new PlayerRecorder(player);
        }

        public static void Destruct(Player player)
        {
            if (player?.UserId == null)
                return;

            PlayerRecorders.Remove(player.UserId);
        }

        internal void AddKillRecord(KillRecord record)
        {
            KillRecordList.Add(record);

            KillCount++;
            RoleKillCount[record.VictimRole]++;

            RoleKillCountAfterRevive[record.VictimRole]++;
            KillCountAfterRevive++;
        }

        internal void AddDeathRecord(DeathRecord record)
        {
            DeathRecordList.Add(record);

            DeathCount++;
            if (record.KillerId != null)
                RoleDeathCount[record.KillerRole]++;
            DeathCountAsRole[record.VictimRole]++;

            foreach (RoleTypeId roleType in Enum.GetValues(typeof(RoleTypeId)))
            {
                RoleKillCountAfterRevive[roleType] = 0;
            }
            KillCountAfterRevive = 0;
        }

        public static int GetKillCount(Player player)
        {
            if (player?.UserId == null)
                return 0;

            return GetOrCreate(player).KillRecordList.Count;
        }

        public static int GetRoleKillCount(Player player, RoleTypeId role)
        {
            if (player?.UserId == null)
                return 0;

            return GetOrCreate(player).KillRecordList.Count(x => x.VictimRole == role);
        }

        public static int GetKillCountAfterRevive(Player player)
        {
            if (player?.UserId == null)
                return 0;

            var recorder = GetOrCreate(player);

            return recorder.KillRecordList.Count(x => x.Time > recorder.DeathRecordList.Last().Time);
        }

        public static int GetDeathCount(Player player)
        {
            if (player?.UserId == null)
                return 0;

            return GetOrCreate(player).DeathRecordList.Count;
        }

        public static int GetRoleDeathCount(Player player, RoleTypeId role)
        {
            if (player?.UserId == null)
                return 0;

            return GetOrCreate(player).DeathRecordList.Count(x => x.VictimRole == role);
        }

        public class KillRecord
        {
            public DateTime Time { get; } = DateTime.Now;

            public string KillerId { get; }
            public string VictimId { get; }

            public RoleTypeId KillerRole { get; }
            public RoleTypeId VictimRole { get; }

            public KillRecord(string killerId, string victimId, RoleTypeId killerRole, RoleTypeId victimRole)
            {
                KillerId = killerId;
                VictimId = victimId;
                KillerRole = killerRole;
                VictimRole = victimRole;
            }
        }

        public class DeathRecord
        {
            public DateTime Time { get; } = DateTime.Now;

            /// <summary>
            /// Could be null!
            /// </summary>
            public string KillerId { get; }
            public string VictimId { get; }

            public RoleTypeId KillerRole { get; }
            public RoleTypeId VictimRole { get; }

            public DeathRecord(string killerId, string victimId, RoleTypeId killerRole, RoleTypeId victimRole)
            {
                KillerId = killerId;
                VictimId = victimId;
                KillerRole = killerRole;
                VictimRole = victimRole;
            }
        }
    }
}
