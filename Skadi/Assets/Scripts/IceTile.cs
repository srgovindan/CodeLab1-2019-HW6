using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTile : Tile
{
    public Material CrackedIceMaterial;
    public Material BrokenIceMaterial;
    public bool tileCracked;

    public override void PlayerSteppedOnTile()
    {
        base.PlayerSteppedOnTile();
        if (!tileCracked)
        {
            tileCracked = true;
            //change texture
            GetComponent<Renderer>().material = CrackedIceMaterial;
            //sfx
            AudioManager.AM.PlayAudioClip(3);
        }
       else
        {
            //change texture
            GetComponent<Renderer>().material = BrokenIceMaterial;
            //play sfx
            AudioManager.AM.PlayAudioClip(4);
            
            StartCoroutine(GridManager.GM.DelayedLoadLevel(3f));//delay before reloading a level
            //reload from GM
            GridManager.GM.LoadLevel(GridManager.GM.levelNum);
        }
    }
}
