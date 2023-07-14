using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace Jhague.KnifetoSword
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class KnifeDamagePlugin_BZ : BaseUnityPlugin
    {
        private const string myGUID = "com.Jhague.KnifeToSword";
        private const string pluginName = "Knife Damage Mod BZ";
        private const string versionString = "1.0.2";
        public static ConfigEntry<float> ConfigKnifeDamageMultiplier;
        public static ConfigEntry<float> ConfigKnifeRangeMultiplier;
        private static readonly Harmony harmony = new Harmony(myGUID);

        public static ManualLogSource logger;

        private void Awake()
        {
            ConfigKnifeDamageMultiplier = Config.Bind("General",        
                "KnifeDamageMultiplier",                                
                1.0f,                                                   
                "Knife damage multiplier.");
            ConfigKnifeRangeMultiplier = Config.Bind("General",
                "Knife Range Mulitplier",
                3.0f,
                "Knife Range Multipler.");


            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "loaded.");
            logger = Logger;
        }
    }
}
