using HarmonyLib;
using Kitchen;
using TMPro;

namespace KitchenNamesAboveHeads
{
    [HarmonyPatch(typeof(PlayerView))]
    public class PlayerView_Patch
    {
        [HarmonyPatch("Update")]
        [HarmonyPrefix]
        public static bool Update_PrefixPatch(PlayerView __instance)
        {
            Traverse PV = Traverse.Create(__instance);
            PV.Field("UseNameLabel").SetValue(true);
            return true;
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        public static void Update_PostfixPatch(PlayerView __instance)
        {
            Traverse PV = Traverse.Create(__instance);
            TextMeshPro nameLabel = (TextMeshPro)PV.Field("NameLabel").GetValue();
            PlayerView.ViewData data = (PlayerView.ViewData)PV.Field("Data").GetValue();
            nameLabel.text = Players.Main.Get(data.PlayerID).Name;
            PV.Field("NameLabel").SetValue(nameLabel);
        }
    }
}
