using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    private int maximumLife = 7;

    public Image[] bars;

    private void Update()
    {
        if (health > maximumLife)
            health = maximumLife;

        for (int i = 0; i < bars.Length; i++)
        {
            if (i < health)
                bars[i].enabled = true;
            else
                bars[i].enabled = false;
        }

        //Debug codes
        if (Input.GetKeyDown(KeyCode.H))
            health--;

        if (Input.GetKeyDown(KeyCode.J))
            health++;
    }
}
