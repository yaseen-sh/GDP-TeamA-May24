using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public static int direction = 1;
    public Image filledBar;
    public int filledPercent = 100;
    public int newPercent = 100;

    // Dealt with in percents so the actual health isnt relevant to how the bar acts

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(filledPercent > newPercent)
        {
            filledPercent--;
        }
    }

    void SubtractHealth(int current, int DecreaseAmount)
    {
        newPercent = filledPercent - (current - DecreaseAmount)/100;
    }

    void resetHealth()
    {
        filledPercent = 100;
        newPercent = 100;
    }
}
