using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairColorSelector : MonoBehaviour
{
    private Color color;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
       color = GetComponent<Image>().Color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectColor() {
        //assign color of button to player
    }
}

//Variable for color 
//Write method that when button is selected, assign to color variable
//Maybe assign the color to player?
//Need player manager - stores player index and color
//Need to rework code to apply to multiple players
