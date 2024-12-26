using CustomizableUIMeow.Utilities.UI;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using System;

namespace CustomizableUIMeow
{
    public static class EventHandler
    {
        public static void OnVerified(VerifiedEventArgs ev)
        {
            if (ev.Player == null ||
                ev.Player.IsVerified == false ||
                ev.Player.UserId == null ||
                ev.Player.ReferenceHub?.isLocalPlayer == true)
                return;

            DisplayManager.GetOrCreate(ev.Player).SetTemplate();
        }

        public static void OnLeft(LeftEventArgs ev)
        {
            DisplayManager.Destruct(ev.Player);
        }

        public static void OnChangingRole(ChangingRoleEventArgs ev)
        {
            Timing.CallDelayed(0f, () =>
            {
                if (ev.Player == null)
                    return;

                try
                {
                    DisplayManager.GetOrCreate(ev.Player).SetTemplate();
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
            });
        }
    }
}
