using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
namespace Pizzatime
{
    [BepInPlugin("Pizza.run", "Pizzatimemod", "1.0.0")]
    public class Pizzamod : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("Pizza.run");

        private static Pizzamod Instance;
        internal ManualLogSource mls;
        void Awake()
        {
           if (Instance == null)
            { 
                Instance = this; 
            }

           mls = BepInEx.Logging.Logger.CreateLogSource("Pizzatimemod");
           mls.LogInfo("Pizzatimemod started !");
            harmony.PatchAll();
        }
    }
}


