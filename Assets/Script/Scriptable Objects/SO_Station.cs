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
    public Sprite sprite_rankinactive;
    public Sprite sprite_rankactive;

    // Var int --
    public int upgrade;
    public int maximumUpgrade;
    public int breakChance;
    public int intialBreakChance;
    public int state;

    // Var bools --
    public bool maxUpgrade;
    public bool broken;
    public bool bought;
    public bool process;
    public bool item;

public void None()
{
    bought = false;
    state = 5;
    Debug.Log("this station has not been purchased it.");
}

public void Purchased()
{
    bought = true;
    state = 4;
    intialBreakChance = 300;
    Debug.Log("this station has been bought!");
    
}

public void Upgrade()
{
    upgrade += 1;
    state = 4;
    Debug.Log("this station has been upgraded!");
    
}

public void MaxUpgrade()
{
    maxUpgrade = true;
    state = 0;
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
    state = 1;
    Debug.Log("stove has finished a dish!");

}

public void Broken()
{
    broken = true;
    state = 3;
    Debug.Log("the stove is broken.");

}

public void Fixed()
{
    broken = false;
    state = 4;
    Debug.Log("the stove is fixed!");

}

}





