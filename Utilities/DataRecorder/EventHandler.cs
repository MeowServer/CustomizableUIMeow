using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System.Linq;


namespace CustomizableUIMeow.Utilities.DataRecorder
{
    public static class EventHandler
    {
        public static void BindEvent()
        {
            Exiled.Events.Handlers.Player.Died += OnDied;
            Exiled.Events.Handlers.Player.Verified += OnVerified;
            Exiled.Events.Handlers.Player.Left += OnLeft;
        }

        public static void UnbindEvent()
        {
            Exiled.Events.Handlers.Player.Died -= OnDied;
            Exiled.Events.Handlers.Player.Verified -= OnVerified;
            Exiled.Events.Handlers.Player.Left -= OnLeft;
        }

        public static void OnDied(DiedEventArgs ev)
        {
            if (ev.Player?.UserId == null) //Check if player or it's id is null
                return;

            //Add death record
            PlayerRecorder.GetOrCreate(ev.Player).AddDeathRecord(new PlayerRecorder.DeathRecord(
                    ev.Attacker?.UserId, 
                    ev.Player.UserId, 
                    ev.Attacker?.Role.Type??RoleTypeId.None, 
                    ev.TargetOldRole)
                );

            //Fix scp 106 kill record
            if (ev.DamageHandler.Type == DamageType.PocketDimension)
            {
                foreach (Player scp106 in Player.List.Where(x => x.Role == RoleTypeId.Scp106))
                {
                    PlayerRecorder.GetOrCreate(scp106).AddKillRecord(new PlayerRecorder.KillRecord(
                        ev.Attacker?.UserId,
                        ev.Player.UserId,
                        ev.Attacker?.Role.Type ?? RoleTypeId.None,
                        ev.TargetOldRole)
                    );
                }

                return;
            }

            //Add kill record if attacker is not null
            if (ev.Attacker != null)
            {
                PlayerRecorder.GetOrCreate(ev.Attacker).AddKillRecord(new PlayerRecorder.KillRecord(
                        ev.Attacker?.UserId,
                        ev.Player.UserId,
                        ev.Attacker?.Role.Type ?? RoleTypeId.None,
                        ev.TargetOldRole)
                    );
            }
        }

        public static void OnVerified(VerifiedEventArgs ev)
        {
            if (ev.Player?.UserId == null)
                return;

            if (ev.Player != null)
            {
                PlayerRecorder.GetOrCreate(ev.Player);
            }
        }

        public static void OnLeft(LeftEventArgs ev)
        {
            if (ev.Player?.UserId == null)
                return;

            if (ev.Player != null)
            {
                PlayerRecorder.Destruct(ev.Player);
            }
        }
    }
}
