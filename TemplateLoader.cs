using CustomizableUIMeow.UITemplates;
using Exiled.API.Features;
using HintServiceMeow;
using MEC;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CustomizableUIMeow
{
    public class TemplateLoader
    {
        private static List<TemplateLoader> loaders = new List<TemplateLoader>();

        private Player player;

        //Template
        private PlayerUITemplateBase template;
        private CoroutineHandle templateUpdateCoroutine;
        
        //internal methods
        internal TemplateLoader(Player player)
        {
            this.player = player;
            SetTemplate();

            loaders.Add(this);
        }

        internal static void RemoveTemplateLoader(Player player)
        {
            loaders.FindAll(x => x.player == player)?.ForEach(x => x.Destruct());
        }

        //Private Template Methods

        //Template setters
        private void SetTemplate()
        {
            StopTemplateCoroutine();

            template?.DestructTemplate();

            if (PlayerUICommonTools.IsCustomRole(player))
            {
                if (PlayerUICommonTools.IsSCP(player))
                {
                    template = new CustomSCPTemplate(player);
                }
                else
                {
                    template = new CustomHumanTemplate(player);
                }
            }
            else
            {
                if (player.IsAlive && player.IsHuman)
                {
                    template = new GeneralHumanTemplate(player);
                }
                else if (player.IsAlive && player.IsScp)
                {
                    template = new SCPTemplate(player);
                }
                else if (player.Role.Type == RoleTypeId.Spectator)
                {
                    template = new SpectatorTemplate(player);
                }
                else
                {
                    template = null;
                }
            }

            template?.SetUpTemplate();
            StartTemplateCoroutine();
        }

        private bool CheckTemplate()
        {
            bool isCorrectType;

            if (PlayerUICommonTools.IsCustomRole(player))
            {
                if (PlayerUICommonTools.IsSCP(player))
                {
                    isCorrectType = template?.type == PlayerUITemplateBase.PlayerUITemplateType.CustomSCP;
                }
                else
                {
                    isCorrectType = template?.type == PlayerUITemplateBase.PlayerUITemplateType.CustomHuman;
                }
            }
            else
            {
                if (player.IsAlive && player.IsHuman)
                {
                    isCorrectType = template?.type == PlayerUITemplateBase.PlayerUITemplateType.GeneralHuman;
                }
                else if (player.IsAlive && player.IsScp)
                {
                    isCorrectType = template?.type == PlayerUITemplateBase.PlayerUITemplateType.SCP;
                }
                else if (player.Role.Type == RoleTypeId.Spectator)
                {
                    isCorrectType = template?.type == PlayerUITemplateBase.PlayerUITemplateType.Spectator;
                }
                else
                {
                    isCorrectType = template == null;
                }
            }

            return isCorrectType;
        }

        //Coroutine
        private IEnumerator<float> TemplateUpdateCoroutineMethod()
        {
            while (true)
            {
                try
                {
                    if (player.IsConnected)
                    {
                        if (!CheckTemplate())
                        {
                            SetTemplate();
                        }

                        template?.UpdateTemplate();
                    }
                }
                catch (Exception ex)
                {
                }

                yield return Timing.WaitForSeconds(0.1f);
            }
        }

        private void StartTemplateCoroutine()
        {
            if (templateUpdateCoroutine.IsRunning)
                Timing.KillCoroutines(templateUpdateCoroutine);

            templateUpdateCoroutine = Timing.RunCoroutine(TemplateUpdateCoroutineMethod());
        }

        private void StopTemplateCoroutine()
        {
            if (templateUpdateCoroutine.IsRunning)
                Timing.KillCoroutines(templateUpdateCoroutine);
        }

        //Destructor
        private void Destruct()
        {
            StopTemplateCoroutine();
            template?.DestructTemplate();

            loaders.Remove(this);
        }
    }
}
