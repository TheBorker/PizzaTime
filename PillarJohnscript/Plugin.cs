using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using JetBrains.Annotations;
using LethalLib.Modules;
using UnityEngine;



namespace PillarJohnscript
{
    [BepInPlugin("com.pillarjohn.pillarjohncore", "PillarJohnCore", "1.0.0")]
    [BepInDependency("evaisa.lethallib", BepInDependency.DependencyFlags.HardDependency)]
    public class PillarJohnCore : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("com.pillarjohn.pillarjohncore");
        private static PillarJohnCore instance;
        internal ManualLogSource nls;


        public static bool PizzaTime = false;
        


        void Awake()
        {
            instance = this;
            
            Logger.LogInfo("PillarJohnCore plugin loaded successfully.");
            // Initialize the logger
            nls = BepInEx.Logging.Logger.CreateLogSource("PillarJohnCore");
            nls.LogInfo("Logger initialized successfully, Pillar John is watching...");

            // Asset directory setup

            string assetDir = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "pillarjohnassetbundle");
            
            AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);

            // Item Setup

            Item pillarjohn = bundle.LoadAsset<Item>("Assets/PillarJohnItem.asset");
            NetworkPrefabs.RegisterNetworkPrefab(pillarjohn.spawnPrefab);

          

            Utilities.FixMixerGroups(pillarjohn.spawnPrefab);
            // this is for the empty diagetic mixer group in the asset bundle, and it generally fixes sound issues
            Items.RegisterScrap(pillarjohn,1000,Levels.LevelTypes.All);
           
            // Harmony patching
            harmony.PatchAll(typeof(PillarJohnCore));

           


        }

    }
}


