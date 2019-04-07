using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            
            //reload from GM
            GridManager.GM.ReloadLevel();
           //TODO:call a GM function to reload
        }
    }
}
