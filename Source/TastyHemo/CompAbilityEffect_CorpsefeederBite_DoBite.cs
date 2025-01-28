using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace TastyHemo.HarmonyPatches;

/// <summary>
///     Compatibility with Vanilla Races Expanded - Sanguophage
/// </summary>
[HarmonyPatch]
public static class CompAbilityEffect_CorpsefeederBite_DoBite
{
    public static bool Prepare()
    {
        if (!ModsConfig.IsActive("vanillaracesexpanded.sanguophage"))
        {
            return false;
        }

        Log.Message("[TastyHemo]: Patching for CorpseFeeder bite in Vanilla Races Expanded - Sanguophage");
        return true;
    }

    public static MethodBase TargetMethod()
    {
        return AccessTools.Method(
            AccessTools.TypeByName("VanillaRacesExpandedSanguophage.CompAbilityEffect_CorpsefeederBite"), "DoBite");
    }

    public static bool Prefix(Pawn biter, Corpse corpse, ref float nutritionGain)
    {
        nutritionGain = IMJ_Settings.TH_NutritionfromBloodFeed * (corpse.InnerPawn?.BodySize ?? 1f);
        if (IMJ_Settings.TH_MoodletfromBloodFeed)
        {
            biter.needs.mood?.thoughts?.memories?.TryGainMemory(ThoughtDef.Named("IMJ_LavishSippy"));
        }

        return true;
    }
}