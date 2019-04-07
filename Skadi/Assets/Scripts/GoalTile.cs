using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTile : Tile
{
    public override void PlayerSteppedOnTile()
    {
       //if the ice tiles are all broken load next level
       if (GridManager.GM.CheckIfAllIceTilesCracked())
       {
           GridManager.GM.levelNum++;
           GridManager.GM.LoadLevel(GridManager.GM.levelNum);
       }
       //else move the player back 
       else
       {
           //play sfx
           AudioManager.AM.PlayAudioClip(5);
           //reload from GM
           GridManager.GM.ReloadLevel();
       }
    }
}
