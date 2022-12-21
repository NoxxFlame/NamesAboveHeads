using HarmonyLib;
using KitchenMods;

namespace KitchenNamesAboveHeads
{
    internal class NamesAboveHeads : IModInitializer
    {
        public void PostActivate(Mod mod)
        {
            var harmony = new Harmony("noxxflame.plateup.namesaboveheads");
            harmony.PatchAll(GetType().Assembly);
        }

        public void PreInject() { }

        public void PostInject() { }
    }
}
