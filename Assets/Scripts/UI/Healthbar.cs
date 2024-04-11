using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public static int direction = 1;
    private Image filledBar;
    private Slider sliderBar;
    public GameObject filledBarGO;
    public double filledPercent = 100;
    public double newPercent = 100;

    // Dealt with in percents so the actual health isnt relevant to how the bar acts

    // Start is called before the first frame update
    void Start()
    {
        sliderBar = filledBarGO.GetComponent<Slider>();
        //filledBar.type = Image.Type.Filled;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(filledPercent > newPercent)
        {
            filledPercent-=0.5;
            sliderBar.value = ((float)(filledPercent / 100));
          //  Debug.Log((float)(filledPercent/100));
        }
    }

    void SubtractHealth(int initialHealth, int DecreaseAmount)
    {
        newPercent = filledPercent - DecreaseAmount/initialHealth;
    }

    void resetHealth()
    {
        filledPercent = 100;
        newPercent = 100;
    }
}
