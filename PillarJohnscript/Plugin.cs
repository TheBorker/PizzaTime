using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;


namespace PillarJohnscript
{
    [BepInPlugin("com.pillarjohn.pillarjohncore", "PillarJohnCore", "1.0.0")]
    public class PillarJohnCore : BaseUnityPlugin 
    {
        private readonly Harmony harmony = new Harmony("com.pillarjohn.pillarjohncore");
        private static PillarJohnCore instance;
        internal ManualLogSource nls;
        void Awake()
        {
            instance = this;
            
            Logger.LogInfo("PillarJohnCore plugin loaded successfully.");
            // Initialize the logger
            nls = BepInEx.Logging.Logger.CreateLogSource("PillarJohnCore");
            nls.LogInfo("Logger initialized successfully, Pillar John is watching...");
            // Apply Harmony patches
            harmony.PatchAll(typeof(PillarJohnCore));
        }
        
    }
}
