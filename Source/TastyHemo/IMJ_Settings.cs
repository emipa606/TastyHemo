using UnityEngine;
using Verse;

namespace TastyHemo;

public class IMJ_Settings : ModSettings
{
    public static float ThNutritionfromBloodFeed = 0.45f;

    public static bool ThMoodletfromBloodFeed = true;

    public void DoWindowContents(Rect inRect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);
        listingStandard.Gap();
        listingStandard.Label("TaHe.BiterLabel".Translate(ThNutritionfromBloodFeed.ToStringPercent()));
        ThNutritionfromBloodFeed = listingStandard.Slider(ThNutritionfromBloodFeed, 0f, 2f);
        listingStandard.CheckboxLabeled("TaHe.ShouldGet".Translate(), ref ThMoodletfromBloodFeed);

        if (listingStandard.ButtonText("TaHe.Reset".Translate()))
        {
            ThNutritionfromBloodFeed = 0.45f;
            ThMoodletfromBloodFeed = true;
        }

        if (IMJ_Mod.CurrentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("TaHe.ModVersion".Translate(IMJ_Mod.CurrentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }

    public override void ExposeData()
    {
        Scribe_Values.Look(ref ThNutritionfromBloodFeed, "TH_NutritionfromBloodFeed", 0.45f);
        Scribe_Values.Look(ref ThMoodletfromBloodFeed, "TH_MoodletfromBloodFeed", true);
    }
}