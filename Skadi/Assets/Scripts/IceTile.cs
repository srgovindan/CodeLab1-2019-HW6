using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTile : Tile
{
    public Material CrackedIceMaterial;
    public Material BrokenIceMaterial;
    int health = 2;

    public override void PlayerSteppedOnTile()
    {
        base.PlayerSteppedOnTile();
        //health--;
        if (health == 1)
        {
            //if health 2, change texture to cracked tile
            GetComponent<Renderer>().material = CrackedIceMaterial;
            //GetComponent<Material>().SetTexture(1,CrackedIceTexture);
            //crack tile sfx
            AudioManager.AM.PlayAudioClip(3);
        }
        else
        {
            //if health >=1, player loses and reset level 
//            Player player = GridManager.player.GetComponent<Player>();
//            //player.canMove = false;
//            player.PlayerFallAnimation();
            //reload level
            
        }
        Player player = GridManager.player.GetComponent<Player>();
        //player.canMove = false;
        player.PlayerFallAnimation();
        
    }
}
