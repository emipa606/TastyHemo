using UnityEngine;
using Verse;

namespace TastyHemo;

public class IMJ_Settings : ModSettings
{
    public static float TH_NutritionfromBloodFeed = 0.45f;

    public static bool TH_MoodletfromBloodFeed = true;

    public void DoWindowContents(Rect inRect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(inRect);
        listing_Standard.Gap();
        listing_Standard.Label("TaHe.BiterLabel".Translate(TH_NutritionfromBloodFeed.ToStringPercent()));
        TH_NutritionfromBloodFeed = listing_Standard.Slider(TH_NutritionfromBloodFeed, 0f, 2f);
        listing_Standard.CheckboxLabeled("TaHe.ShouldGet".Translate(), ref TH_MoodletfromBloodFeed);

        if (listing_Standard.ButtonText("TaHe.Reset".Translate()))
        {
            TH_NutritionfromBloodFeed = 0.45f;
            TH_MoodletfromBloodFeed = true;
        }

        if (IMJ_Mod.currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("TaHe.ModVersion".Translate(IMJ_Mod.currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }

    public override void ExposeData()
    {
        Scribe_Values.Look(ref TH_NutritionfromBloodFeed, "TH_NutritionfromBloodFeed", 0.45f);
        Scribe_Values.Look(ref TH_MoodletfromBloodFeed, "TH_MoodletfromBloodFeed", true);
    }
}