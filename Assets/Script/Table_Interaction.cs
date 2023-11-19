using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using TMPro;

public class Table_Interaction : MonoBehaviour
{
    public GameObject table;

    public GameObject BuyUI;
    public GameObject FixUI;
    public GameObject UpgradeUI;

    public TextMeshProUGUI displayText;

    public GameObject UpgradeBox1;
    public GameObject UpgradeBox2;
    public GameObject UpgradeBox3;

    public ProgressBar progressBar;

    public uint breakChance;

    private const uint MAX_UPGRADES = 3;
    private const uint INITIAL_BREAKCHANCE = 300;

    private bool bought;
    private bool broken;
    private bool completed;
    private bool fixing;
    private uint numUpgrades;

    public void Trigger()
    {

        if(completed && !broken)
        {
            // Completed so do nothing
            return;
        }
        else if(!bought && (BuyUI.activeInHierarchy == false))
        {
            // Not bought so show the buy menu
            BuyUI.SetActive(true);
        }
        else if(!bought && (BuyUI.activeInHierarchy == true))
        {
            // Unshow the buy menu if it's shown
            BuyUI.SetActive(false);
        }
        else if(!broken && (UpgradeUI.activeInHierarchy == false))
        {
            // It's bought and not broken so show the Upgrade Menu
            UpgradeUI.SetActive(true);
        }
        else if(!broken && (UpgradeUI.activeInHierarchy == true))
        {
            // Unshow the Upgrade Menu if it's shown
            UpgradeUI.SetActive(false);
        }
        else if(broken && (FixUI.activeInHierarchy == false))
        {
            // It's broken so show the Fix Menu
            FixUI.SetActive(true);
        }
        else
        {
            // Unshow the Fix Menu
            FixUI.SetActive(false);
        }
    }

    public void doBuy()
    {
        // Set the bought flag and close the Buy Menu
        bought = true;
        BuyUI.SetActive(false);
    }

    public void doUpgrade()
    {
        // Add a level to the upgrade
        if (!completed && !progressBar.isActive())
        {
            numUpgrades++;
            switch(numUpgrades)
            {
                case 3:
                    // Turn on the third box
                    UpgradeBox3.SetActive(true);
                    displayText.SetText("Level 3");
                    break;
                case 2:
                    // Turn on the second box
                    UpgradeBox2.SetActive(true);
                    displayText.SetText("Level 2");
                    break;
                case 1:
                    // Turn on the first box
                    UpgradeBox1.SetActive(true);
                    displayText.SetText("Level 1");
                    break;
                case 0:
                default:
                    //do nothing
                    break;
            }
            if (numUpgrades == MAX_UPGRADES)
            {
                // If completed, set the completed flag and close the Upgrade Menu
                completed = true;
                UpgradeUI.SetActive(false);
            }
            progressBar.doProgress();
        }
    }

    public void doBreak()
    {
        // Set the broken flag, close the Upgrade Menu, change the sprite to broken
        broken = true;
        UpgradeUI.SetActive(false);
    }

    public void doFix()
    {
        // Start the progress bar and close the Fix Menu
        fixing = true;
        progressBar.doProgress();
        FixUI.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        breakChance = INITIAL_BREAKCHANCE;
    }

    // Update is called once per frame
    void Update()
    {
        // Break every once in a while
        int temp;
        if (bought && !broken)
        {
            temp = UnityEngine.Random.Range(0, 1000000);
            if (temp < breakChance)
            {
                doBreak();
            }
        }
        if((fixing == true) && (!progressBar.isActive()))
        {
            fixing = false;
            broken = false;
        }
    }
}
