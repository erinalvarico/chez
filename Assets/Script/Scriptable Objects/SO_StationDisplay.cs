using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SO_StationDisplay : MonoBehaviour
{
    public SO_Station station;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI buttonText;

    public SpriteRenderer appearance;
    public SpriteRenderer item;
    public Image recipe;

    public Image Rank1;
    public Image Rank2;
    public Image Rank3;

    public GameObject GUIInteraction;
    public ProgressBar progressBar;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = station.type;
        levelText.text = ("Level " + station.upgrade);
        buttonText.text = "BUY";
        buttonText.SetText(buttonText.text);
        item.enabled = false;
        appearance.sprite = station.sprite_inactive;

        station.breakChance = SO_Station.INITIAL_BREAK_CHANCE;
        station.upgrade = 0;
        station.maximumUpgrade = 3;
        station.maxUpgrade = false;
        station.broken = false;
        station.bought = false;
        station.process = false;
        station.item = false;

    station.None();
        Debug.Log(nameText.text + " is inactive.");
    }

    public void Trigger()
    {
        Debug.Log("Trigger!");
        Debug.Log("Bought? " + station.bought + " Broken? " + station.broken);
        if(station.maxUpgrade && !station.broken)
        {
            // Completed so do nothing
            return;
        }
        else if(!station.bought && (GUIInteraction.activeInHierarchy == false))
        {
            // Not bought so show the buy menu
            nameText.SetText(nameText.text);
            levelText.SetText(levelText.text);
            buttonText.SetText("BUY");
            Debug.Log(nameText.text + " is not purchased.");
            GUIInteraction.SetActive(true);
        }
        else if(!station.bought && (GUIInteraction.activeInHierarchy == true))
        {
            // Unshow the buy menu if it's shown
            Debug.Log(nameText.text + " is not purchased.");
            GUIInteraction.SetActive(false);
        }
        else if(!station.broken && (GUIInteraction.activeInHierarchy == false))
        {
            // It's bought and not broken so show the Upgrade Menu
            nameText.SetText(nameText.text);
            levelText.SetText(levelText.text);
            buttonText.SetText("UPGRADE");
            Debug.Log(nameText.text + " is purchased, and upgradable.");
            GUIInteraction.SetActive(true);
        }
        else if(!station.broken && (GUIInteraction.activeInHierarchy == true))
        {
            // Unshow the Upgrade Menu if it's shown
            Debug.Log(nameText.text + " is purchased, and upgradable.");
            GUIInteraction.SetActive(false);
        }
        else if(station.broken && (GUIInteraction.activeInHierarchy == false))
        {
            // It's broken so show the Fix Menu
            nameText.SetText(nameText.text);
            levelText.text = "Station is broken!";
            levelText.SetText(levelText.text);
            buttonText.SetText("FIX IT!");
            Debug.Log(nameText.text + " is broken.");
            GUIInteraction.SetActive(true);
        }
        else
        {
            // Unshow the Fix Menu
            Debug.Log(nameText.text + " is broken.");
            GUIInteraction.SetActive(false);
        }
    }

    public void interaction()
    {
        Debug.Log(station.stateVar);
        switch (station.stateVar)
        {
            case SO_Station.state.Inactive:
                // not purchased
                doBuy();
                break;
            case SO_Station.state.Upgrade0:
            case SO_Station.state.Upgrade1:
            case SO_Station.state.Upgrade2:
                // purchase upgrade
                doUpgrade();
                break;
            case SO_Station.state.Broken:
                // fix station
                doFix();
                break;
            case SO_Station.state.MaxUpgrade:
                // do nothing: fully upgraded
            default:
                // do nothing
                break;
/*
            case 2:
                // cook recipe
                doCook();
                buttonText.text = "COOK UP!";
                buttonText.SetText(buttonText.text);
                break;
            case 1:
                // item present
                itemPresent();
                buttonText.text = "SERVE IT UP!";
                buttonText.SetText(buttonText.text);
                break;
*/
        }
    }

    public void doBuy()
    {
        // Set the bought flag and close the Buy Menu
        station.Purchased();
        item.enabled = false;
        appearance.sprite = station.sprite_active;
        GUIInteraction.SetActive(false);
    }

    public void doUpgrade()
    {
        // Add a level to the upgrade
        if (!station.maxUpgrade && !progressBar.isActive())
        {
            station.Upgrade();
            switch (station.upgrade)
            {
                case 3:
                    // Turn on the third box
                    Rank3.sprite = station.sprite_rankactive;
                    levelText.text = "Level 3";
                    levelText.SetText(levelText.text);
                    break;
                case 2:
                    // Turn on the second box
                    Rank2.sprite = station.sprite_rankactive;
                    levelText.text = "Level 2";
                    levelText.SetText(levelText.text);
                    break;
                case 1:
                    // Turn on the first box
                    Rank1.sprite = station.sprite_rankactive;
                    levelText.text = "Level 1";
                    levelText.SetText(levelText.text);
                    break;
                case 0:
                default:
                    //do nothing
                    break;
            }
            if (station.upgrade == station.maximumUpgrade)
            {
                // If completed, set the completed flag and close the Upgrade Menu
                GUIInteraction.SetActive(false);
            }
            progressBar.doProgress();
        }
    }

    public void doBreak()
    {
        // Set the broken flag, close the Upgrade Menu, change the sprite to broken
        station.Broken();
        appearance.sprite = station.sprite_broken;
        item.enabled = false;
        GUIInteraction.SetActive(false);
    }

    public void doFix()
    {
        // Start the progress bar and close the Fix Menu
        Debug.Log("Do Fix");
        station.Process();
        progressBar.doProgress();
        station.Fixed();
        appearance.sprite = station.sprite_active;
        GUIInteraction.SetActive(false);
    }

    public void doCook()
    {
        // Start the progress bar and close the Cook Menu
        station.Process();
        progressBar.doProgress();
        GUIInteraction.SetActive(false);
    }

    public void itemPresent()
    {
        // Set the item flag and close the Cook Menu
        station.Item();
        item.enabled = true;
        item.sprite = station.sprite_item;
        GUIInteraction.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Break every once in a while
        int temp;
        if (station.bought && !station.broken)
        {
            temp = UnityEngine.Random.Range(0, 1000000);
            if (temp < station.breakChance)
            {
                doBreak();
            }
        }
        /*
        if((station.process == true) && (!progressBar.isActive()))
        {
            station.Process();
            station.Broken();
        }
        */
    }
}
