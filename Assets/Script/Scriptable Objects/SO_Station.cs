using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Station", menuName = "Station")]
public class SO_Station : ScriptableObject
{
    // Var string --
    public new string type;

    // Var sprite --
    public Sprite sprite_inactive;
    public Sprite sprite_active;
    public Sprite sprite_process;
    public Sprite sprite_item;
    public Sprite sprite_broken;

    // Var int --
    public int upgrade;
    public int maximumUpgrade;

    // Var bools --
    public bool maxUpgrade = false;
    public bool broken = false;
    public bool bought;
    public bool process;
    public bool item;

public void None()
{
    bought = false;
    //Debug.Log("this station has not been purchased it.");
}

public void Purchased()
{
    bought = true;
    Debug.Log("this station has been bought!");
    
}

public void Upgrade()
{
    upgrade += 1;
    Debug.Log("this station has been upgraded!");
    
}

public void MaxUpgrade()
{
    maxUpgrade = true;
    Debug.Log("this station is max upgrade!");
    
}

public void Idle()
{
    process = false;
    Debug.Log("stove is ready to cook!");

}

public void Process()
{
    process = true;
    Debug.Log("stove is currently cooking!");

}

public void Item()
{
    item = true;
    Debug.Log("stove has finished a dish!");

}

public void Broken()
{
    broken = true;
    Debug.Log("the stove is broken.");

}

public void Fixed()
{
    broken = false;
    Debug.Log("the stove is fixed!");

}

}





