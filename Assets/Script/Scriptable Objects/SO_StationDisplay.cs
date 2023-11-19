using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SO_StationDisplay : MonoBehaviour
{
    public SO_Station stove;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;

    public SpriteRenderer appearance;
    public Image recipe;

    // Start is called before the first frame update
    void Start()
    {
        stove.None();
        appearance.sprite = stove.sprite_inactive;
      //  Debug.Log("Stove A is inactive.");
    }

    void Update()
    {
        if(!stove.bought)
        {
            stove.None();
            None();
        }    
        else
        {   
            stove.Purchased();
            appearance.sprite = stove.sprite_active;
          //  Debug.Log("Stove A is active.");
        }
    }

    void None()
    {
            appearance.sprite = stove.sprite_inactive;
          //  Debug.Log("Stove A is inactive.");
    }
}
