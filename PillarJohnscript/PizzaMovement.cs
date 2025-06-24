using System;
using HarmonyLib;
using UnityEngine;
using BepInEx;
using LethalLib.Modules;
using GameNetcodeStuff;
using PillarJohnscript;

[HarmonyPatch(typeof(GrabbableObject), "GrabItem")]
public class GrabItemPatch
{
    static void Postfix(GrabbableObject __instance, PlayerControllerB grabber)
    {
        if (__instance.itemProperties.itemName == "PillarJohnRoot(Clone)")
        {
            {
                // Check if the player is holding the Pillar John item
                Item heldItem = PlayerUtils.GetHeldItem(grabber);
                if (heldItem != null && heldItem.name == "PillarJohnItem")
                {
                    // Trigger pizza time
                    PillarJohnCore.PizzaTime = true;
                    Debug.Log("Pizza Time has been triggered!");
                }
            }
        }
    }
}