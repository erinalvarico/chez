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
        station.None();
        item.enabled = false;
        appearance.sprite = station.sprite_inactive;
        Debug.Log(nameText + " is inactive.");

        station.breakChance = station.intialBreakChance;
    }

    public void Trigger()
    {

        if(station.maxUpgrade && !station.broken)
        {
            // Completed so do nothing
            return;
        }
        else if(!station.bought && (GUIInteraction.activeInHierarchy == false))
        {
            // Not bought so show the buy menu
            appearance.sprite = station.sprite_inactive;
            Debug.Log(nameText + " is not purchased.");
            GUIInteraction.SetActive(true);
        }
        else if(!station.bought && (GUIInteraction.activeInHierarchy == true))
        {
            // Unshow the buy menu if it's shown
            appearance.sprite = station.sprite_inactive;
            Debug.Log(nameText + " is not purchased.");
            GUIInteraction.SetActive(false);
        }
        else if(!station.broken && (GUIInteraction.activeInHierarchy == false))
        {
            // It's bought and not broken so show the Upgrade Menu
            appearance.sprite = station.sprite_active;
            Debug.Log(nameText + " is purchased, and upgradable.");
            GUIInteraction.SetActive(true);
        }
        else if(!station.broken && (GUIInteraction.activeInHierarchy == true))
        {
            // Unshow the Upgrade Menu if it's shown
            appearance.sprite = station.sprite_active;
            Debug.Log(nameText + " is purchased, and upgradable.");
            GUIInteraction.SetActive(false);
        }
        else if(station.broken && (GUIInteraction.activeInHierarchy == false))
        {
            // It's broken so show the Fix Menu
            appearance.sprite = station.sprite_broken;
            Debug.Log(nameText + " is broken.");
            GUIInteraction.SetActive(true);
        }
        else
        {
            // Unshow the Fix Menu
            appearance.sprite = station.sprite_broken;
            Debug.Log(nameText + " is broken.");
            GUIInteraction.SetActive(false);
        }
    }

    public void interaction()
    {
        switch(station.state)
        {
            case 5:
                // not purchased
                doBuy();
                break;
            case 4:
                // purchase upgrade
                doUpgrade();
                break;
            case 3:
                // fix station
                doFix();
                break;
            case 2:
                // cook recipe
                doCook();
                break;
            case 1:
                // item present
                itemPresent();
                break;       
            case 0:
                // do nothing: fully upgrade
            default:
                // do nothing
                break;
        }
    }

    public void doBuy()
    {
        // Set the bought flag and close the Buy Menu
        station.Purchased();
        item.enabled = false;
        GUIInteraction.SetActive(false);
    }

    public void doUpgrade()
    {
        // Add a level to the upgrade
        if (!station.maxUpgrade && !progressBar.isActive())
        {
            station.upgrade++;
            switch(station.upgrade)
            {
                case 3:
                    // Turn on the third box
                    Rank3.sprite = station.sprite_rankactive;
                    levelText.SetText("Level 3");
                    break;
                case 2:
                    // Turn on the second box
                    Rank2.sprite = station.sprite_rankactive;
                    levelText.SetText("Level 2");
                    break;
                case 1:
                    // Turn on the first box
                    Rank1.sprite = station.sprite_rankactive;
                    levelText.SetText("Level 1");
                    break;
                case 0:
                default:
                    //do nothing
                    break;
            }
            if (station.upgrade == station.maximumUpgrade)
            {
                // If completed, set the completed flag and close the Upgrade Menu
                station.MaxUpgrade();
                GUIInteraction.SetActive(false);
            }
            progressBar.doProgress();
        }
    }

    public void doBreak()
    {
        // Set the broken flag, close the Upgrade Menu, change the sprite to broken
        station.Broken();
        item.enabled = false;
        GUIInteraction.SetActive(false);
    }

    public void doFix()
    {
        // Start the progress bar and close the Fix Menu
        station.Process();
        progressBar.doProgress();
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
        if((station.process == true) && (!progressBar.isActive()))
        {
            station.Process();
            station.Broken();
        }
    }
}
