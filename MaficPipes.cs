using System.Collections.Generic;
using HarmonyLib;
using KMod;

namespace MaficPipes
{
    public class MaficPipesPatches: UserMod2
    {
        [HarmonyPatch(typeof(ElementLoader))]
        [HarmonyPatch("FinaliseElementsTable")]
        public static class ElementLoader_LoadUserElementData_Patch
        {
            public static void Postfix()
            {
                var mafic = ElementLoader.FindElementByHash(SimHashes.MaficRock);
                var tags = new List<Tag>(mafic.oreTags) { new Tag("Plumbable") };
                mafic.oreTags = tags.ToArray();
            }
        }
    }

}
