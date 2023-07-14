using HarmonyLib;
using UnityEngine;

namespace Jhague.KnifetoSword
{
    /// <summary>
    /// Class to mod the knife
    /// </summary>
    public static class KnifeDamageMod_BZ
    {
        [HarmonyPatch(typeof(Knife))]
        public static class Knife_Patch
        {
            [HarmonyPatch(nameof(Knife.Start))]
            [HarmonyPostfix]
            public static void Start_Postfix(Knife __instance)
            {

                float damageMultiplier = KnifeDamagePlugin_BZ.ConfigKnifeDamageMultiplier.Value;
                float rangeMultiplier = KnifeDamagePlugin_BZ.ConfigKnifeRangeMultiplier.Value;
                // Double the knife damage
                float knifeDamage = __instance.damage;
                float newKnifeDamage = knifeDamage * damageMultiplier;
                __instance.damage = newKnifeDamage;
                KnifeDamagePlugin_BZ.logger.LogInfo($"Knife damage was: {knifeDamage}," +
                    $" is now: {newKnifeDamage}");
                float knifeRange = __instance.attackDist;
                float newKnifeRange = knifeRange * rangeMultiplier;
                __instance.attackDist = newKnifeRange;
                KnifeDamagePlugin_BZ.logger.LogInfo($"Knife Range was: {knifeRange}," + 
                    $" the range is now: {newKnifeRange}");
            }
        }
        [HarmonyPatch(typeof(PlayerTool))]
        public static class PlayerTool_Patch
        {
            [HarmonyPatch(nameof(PlayerTool.OnDraw))]
            [HarmonyPostfix]
            public static void OnDraw_Postfix(PlayerTool __instance)
            {

                if (__instance is Knife knife)
                {
                    float rangeMultiplier = KnifeDamagePlugin_BZ.ConfigKnifeRangeMultiplier.Value;
                    knife.transform.localScale = new Vector3(knife.transform.localScale.x, 
                        knife.transform.localScale.y * rangeMultiplier, 
                        knife.transform.localScale.z);
                }
            }
        }
    }
}
