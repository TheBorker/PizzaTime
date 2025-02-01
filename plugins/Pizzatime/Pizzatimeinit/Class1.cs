using BepInEx;
using HarmonyLib;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using LethalLib.Modules;

[BepInPlugin(GUID, NAME, VERSION)]
public class Plugin : BaseUnityPlugin
{
    const string GUID = "Borker.Pizzatime";
    const string NAME = "Pizzatime";
    const string VERSION = "0.0.1";

    public static Plugin Instance;

    void Awake()
    {
        Instance = this;

        string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
        string assetDir = Path.Combine(assemblyPath, "pizzatime_pillarjohn");

        AssetBundle Bundle = AssetBundle.LoadFromFile(assetDir);

        if (Bundle != null)
        {
            ScriptableObject PillarPrefab = Bundle.LoadAsset<GameObject>("Assets/Pizzatimeunitymod/Scraps/Prefabs/PillarJohn 1.prefab");

            if (PillarPrefab != null)
            {
                Utilities.FixMixerGroups(PillarPrefab);
            }
            else
            {
                Logger.LogError("Failed to load prefab PillarJohn 1!");
            }
        }
        else
        {
            Logger.LogError("Failed to load asset bundle!");
        }

        Harmony harmony = new Harmony(GUID);
        harmony.PatchAll(Assembly.GetExecutingAssembly());

        Logger.LogInfo("Pizzatime loaded");
    }
}

