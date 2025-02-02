using BepInEx;
using UnityEngine;
using System.IO;
using System.Reflection;
using LethalLib.Modules; // For Scrap registration
using static LethalLib.Modules.Levels;
using UnityEditor;
[BepInPlugin(GUID, NAME, VERSION)]
public class ScrapLoader : BaseUnityPlugin
{
    const string GUID = "YourNamespace.ScrapLoader";
    const string NAME = "Scrap Loader";
    const string VERSION = "1.0.0";

    public static ScrapLoader Instance;
    private static GameObject scrapPrefab; // Use GameObject directly since UnityEngine is already imported

    void Awake()
    {
        Instance = this;

        // Load the AssetBundle
        string assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "pizzatime_pillarjohn");
        AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);

        if (bundle == null)
        {
            Logger.LogError("Failed to load asset bundle!");
            return;
        }

        // Load the Scrap Prefab
        scrapPrefab = bundle.LoadAsset<GameObject>("Assets/Pizzatimeunitymod/Scraps/Prefabs/PillarJohn 1.prefab");

        if (scrapPrefab == null)
        {
            Logger.LogError("Failed to load PillarJohn prefab!");
            return;
        }

        Logger.LogInfo("PillarJohn prefab loaded successfully!");

        // Register Scrap
        RegisterScrap(scrapPrefab);
    }

    void RegisterScrap(GameObject scrap)
    {
        // Ensure physics components exist
        if (scrap.GetComponent<Rigidbody>() == null)
            scrap.AddComponent<Rigidbody>();

        if (scrap.GetComponent<Collider>() == null)
            scrap.AddComponent<BoxCollider>();

        // Fix Audio with LethalLib
        Utilities.FixMixerGroups(scrap);

        // Register with LethalLib for natural spawning
        Items.RegisterScrap(scrap, 100, LevelTypes.All); // Corrected method call for registering scrap

        Logger.LogInfo("PillarJohn registered as scrap!");
    }
}