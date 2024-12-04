using HarmonyLib;
using RimWorld;
using Verse;

namespace TastyHemo.HarmonyPatches;

[HarmonyPatch(typeof(SanguophageUtility), nameof(SanguophageUtility.DoBite))]
public static class SanguophageUtility_DoBite
{
    public static bool Prefix(Pawn biter, Pawn victim, ref float nutritionGain)
    {
        if (victim.Dead)
        {
            return true;
        }

        nutritionGain = IMJ_Settings.TH_NutritionfromBloodFeed * victim.BodySize;
        if (IMJ_Settings.TH_MoodletfromBloodFeed)
        {
            biter.needs.mood?.thoughts?.memories?.TryGainMemory(ThoughtDef.Named("IMJ_LavishSippy"));
        }

        return true;
    }
}