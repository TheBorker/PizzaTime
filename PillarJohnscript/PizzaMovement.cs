using System;
using HarmonyLib;
using UnityEngine;
using BepInEx;
using LethalLib.Modules;
using GameNetcodeStuff;

[HarmonyPatch(typeof(GrabbableObject), "GrabItem")]
public class GrabItemPatch
{
	static void Postfix(GrabbableObject __instance, PlayerControllerB grabber)
    {
        if (__instance.name == "PillarJohnItem")
        {
            // Check if the player is holding the Pillar John item
            if (grabber.GetHeldItem() != null && grabber.GetHeldItem().name == "PillarJohnItem")
            {
                // Set PizzaTime to true when the item is grabbed
                PillarJohnCore.PizzaTime = true;
                Debug.Log("Pillar John has been grabbed! Pizza Time is now active.");
            }
        }
