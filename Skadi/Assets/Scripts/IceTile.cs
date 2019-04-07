using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTile : Tile
{
    public Material CrackedIceMaterial;
    public Material BrokenIceMaterial;
    bool tileCracked;

    public override void PlayerSteppedOnTile()
    {
        base.PlayerSteppedOnTile();
        if (!tileCracked)
        {
            tileCracked = true;
            //if cracked change texture
            GetComponent<Renderer>().material = CrackedIceMaterial;
            //sfx
            AudioManager.AM.PlayAudioClip(3);
        }
       else
        {
            //player loses and reset level 
            Debug.Log("Lose");
            
//            Player player = GridManager.player.GetComponent<Player>();
//            player.PlayerFallAnimation();
            //reload level
            
        }
    }
}
