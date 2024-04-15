using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SetupStageTiles : MonoBehaviour
{
    public List<StageTile> stageTiles = new List<StageTile>();
    public GameObject stageTilePrefab;

    public List<GameObject> stageTileObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        foreach (StageTile stage in stageTiles)
        {
            displayStageTile(stage);
        }
    }
    void displayStageTile(StageTile stage)
    {
        GameObject tile = Instantiate(stageTilePrefab, transform);
        tile.GetComponentInChildren<TextMeshProUGUI>().text = stage.stageName;
        tile.GetComponentsInChildren<Image>()[1].sprite = stage.stagePicture;
        tile.GetComponentInChildren<Button>().onClick = stage.selectStage;
        stageTileObjects.Add(tile);
    }
}
