using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Action : MonoBehaviour
{
    public GameObject winButton;
    public Slider winBar;
    public SO_Station table;
    public SO_Station stove;
    public SO_Station burner;

    private bool tableHandled;
    private bool stoveHandled;
    private bool burnerHandled;

    // Start is called before the first frame update
    void Start()
    {
        tableHandled = false;
        stoveHandled = false;
        burnerHandled = false;
        winBar.value = 0;
        winButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(table.maxUpgrade + " " + tableHandled + " " + stove.maxUpgrade + " " + stoveHandled + " " + burner.maxUpgrade + " " + burnerHandled + " " + winBar.value);
        if(table.maxUpgrade && !tableHandled)
        {
            winBar.value += winBar.maxValue / 3;
            tableHandled = true;
        }
        if (stove.maxUpgrade  && !stoveHandled)
        {
            winBar.value += winBar.maxValue / 3;
            stoveHandled = true;
        }
        if (burner.maxUpgrade && !burnerHandled)
        {
            winBar.value += winBar.maxValue / 3;
            burnerHandled = true;
        }
        if(winBar.value == winBar.maxValue)
        {
            if(winButton.activeInHierarchy ==  false)
            {
                winButton.SetActive(true);
            }
        }
    }
}
