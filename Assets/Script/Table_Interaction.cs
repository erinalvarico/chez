using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table_Interaction : MonoBehaviour
{
    public GameObject BuyUI;
    public GameObject FixUI;
    public GameObject UpgradeUI;

    public bool bought;
    public bool broken;
    public bool completed;

    private const uint MAX_UPGRADES = 3;
    private uint numUpgrades;

    public void Trigger()
    {
        Debug.Log("Reached here");

        if(completed)
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

    void doUpgrade()
    {
        if (!completed)
        {
            numUpgrades++;
            if (numUpgrades == MAX_UPGRADES)
            {
                completed = true;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
