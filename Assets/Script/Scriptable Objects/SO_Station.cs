using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.VersionControl.ListControl;

[CreateAssetMenu(fileName = "New Station", menuName = "Station")]
public class SO_Station : ScriptableObject
{
    // State Enum
    public enum state
    {
        Inactive = 0,
        Upgrade0 = 1,
        Upgrade1 = 2,
        Upgrade2 = 3,
        MaxUpgrade = 4,
        Broken = 5,
    }

    // Var string --
    public string type;

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
    public state stateVar;

    // Var bools --
    public bool maxUpgrade = false;
    public bool broken = false;
    public bool bought = false;
    public bool process = false;
    public bool item = false;

    public const int INITIAL_BREAK_CHANCE = 33;
    private state lastState;

public void None()
{
    bought = false;
    lastState = state.Inactive;
    stateVar = state.Inactive;
    Debug.Log("this station has not been purchased it.");
}

public void Purchased()
{
    bought = true;
    lastState = stateVar;
    stateVar = state.Upgrade0;
    breakChance = INITIAL_BREAK_CHANCE;
    Debug.Log("this station has been bought!");
    
}

public void Upgrade()
{
    upgrade += 1;
    lastState = stateVar;
    stateVar = state.Upgrade0 + upgrade;
    if(upgrade == maximumUpgrade)
        {
            lastState = stateVar;
            stateVar = state.MaxUpgrade;
        }
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
    lastState = stateVar;
    stateVar = state.Broken;
    Debug.Log("the stove is broken.");

}

public void Fixed()
{
    broken = false;
    stateVar = lastState;
    lastState = state.Broken;
    Debug.Log("the stove is fixed!");

}

}





