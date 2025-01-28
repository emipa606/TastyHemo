using Mlie;
using UnityEngine;
using Verse;

namespace TastyHemo;

public class IMJ_Mod : Mod
{
    public static string currentVersion;

    public IMJ_Mod(ModContentPack content)
        : base(content)
    {
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        base.DoSettingsWindowContents(inRect);
        GetSettings<IMJ_Settings>().DoWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "TastyHemo";
    }
}