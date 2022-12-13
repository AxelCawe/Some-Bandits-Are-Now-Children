using HarmonyLib;
using MCM.Abstractions.Base.Global;
using Some_Bandits_Are_Now_Children.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace Some_Bandits_Are_Now_Children
{
    public class SubModule : MBSubModuleBase
    {
        private static bool PatchesApplied = false;

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            new Harmony("SomeBanditsAreNowChildren").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
