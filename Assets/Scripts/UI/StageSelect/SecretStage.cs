using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SecretStage : MonoBehaviour
{
    public StageTile secretStage;

    public void SelectSecretStage(InputAction.CallbackContext context)
    {
        if (SceneManager.GetActiveScene().name != "StageSelect") return;

        if (context.action.IsPressed())
        {
            CSSManager.stage = secretStage.stagePicture;
            CSSManager.stageName = secretStage.stageName;
            CSSManager.stageTheme = secretStage.stageMusic;

            if (GameObject.Find("AudioManager") != null)
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().StopMusic();
            }
            else if (GameObject.Find("AudioManager2") != null)
            {
                GameObject.Find("AudioManager2").GetComponent<AudioManager>().StopMusic();
            }
            SceneManager.LoadScene("BrawlScene");
        }
    }
}
