using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNetcodeStuff;
using UnityEngine;


public static class PlayerUtils
{
    public static Item GetHeldItem(PlayerControllerB player)
    {
        if (player == null)
        {
            Debug.LogWarning("GetHeldItem called with null player.");
            return null;
        }

        GrabbableObject heldObj = player.currentlyHeldObjectServer;

        if (heldObj == null)
        {
            return null;
        }

        return heldObj.itemProperties;
    }
}






