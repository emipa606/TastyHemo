using System.Reflection;
using HarmonyLib;
using Verse;

namespace TastyHemo;

[StaticConstructorOnStartup]
public static class Main
{
    static Main()
    {
        new Harmony("Imoja.rimworld.TastyHemoBeta.main").PatchAll(Assembly.GetExecutingAssembly());
    }
}