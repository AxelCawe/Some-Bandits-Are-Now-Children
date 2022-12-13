using HarmonyLib;
using MCM.Abstractions.Base.Global;
using SandBox.CampaignBehaviors;
using Some_Bandits_Are_Now_Children.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Library;

namespace Some_Bandits_Are_Now_Children.Patches
{
    [HarmonyPatch(typeof(MobileParty), "FillPartyStacks")]
    public static class AddChildBanditsPatch
    {
        [HarmonyPostfix]
        static void PostFix(MobileParty __instance, PartyTemplateObject pt, int troopNumberLimit = -1)
        {
            if (__instance.IsBandit)
            {
                // Correction
                {
                    if (GlobalSettings<MCMSettings>.Instance.minPercentOfChildrenToAdd > GlobalSettings<MCMSettings>.Instance.maxPercentOfChildrenToAdd)
                    {
                        int temp = GlobalSettings<MCMSettings>.Instance.minPercentOfChildrenToAdd;
                        GlobalSettings<MCMSettings>.Instance.minPercentOfChildrenToAdd = GlobalSettings<MCMSettings>.Instance.maxPercentOfChildrenToAdd;
                        GlobalSettings<MCMSettings>.Instance.maxPercentOfChildrenToAdd = temp;
                    }
                }

                foreach (TroopRosterElement troop in __instance.MemberRoster.GetTroopRoster())
                {
                    
                    CharacterObject childObject = CharacterObject.Find(troop.Character.StringId + "_children");
                    CharacterObject childFemaleObject = CharacterObject.Find(troop.Character.StringId + "_children_female");
                    if (childObject != null) 
                    {
                        float numberPercent = new Random().Next(GlobalSettings<MCMSettings>.Instance.minPercentOfChildrenToAdd, GlobalSettings<MCMSettings>.Instance.maxPercentOfChildrenToAdd + 1);
                        __instance.AddElementToMemberRoster(childObject, MathF.Floor(numberPercent / 100f * troop.Number));
                    }
                        //mobileParty.AddElementToMemberRoster(childObject, MathF.Floor((float)GlobalSettings<MCMSettings>.Instance.minPercentOfChildrenToAdd / 100f * troop.Number)); 
                    if (childFemaleObject != null)
                    {
                        float numberPercent = new Random().Next(GlobalSettings<MCMSettings>.Instance.minPercentOfChildrenToAdd, GlobalSettings<MCMSettings>.Instance.maxPercentOfChildrenToAdd + 1);
                        __instance.AddElementToMemberRoster(childFemaleObject, MathF.Floor(numberPercent / 100f * troop.Number));
                    }
                }
            }
        }
    }
}
