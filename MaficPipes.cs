using System.Collections.Generic;
using HarmonyLib;

namespace MaficPipes
{
    public static class MaficPipesPatches
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
