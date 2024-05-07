using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Stage Tile", menuName = "Stage Tile")]
public class StageTile : ScriptableObject
{
    public string stageName; // Name of Stage
    public Sprite stagePicture; // Picture of Stage
    public Button.ButtonClickedEvent selectStage; // Button Action for Stage
    public AudioClip stageMusic; // Music of Stage
}
