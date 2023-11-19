using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public Item[] Items;
    

    private void Awake()
    {
        Instance = this;
        Items = Utils.GetAllInstances<Item>();
        Items = Items.OrderBy(p => p.Id).ToArray();

        foreach(Item item in Items)
        {
            Debug.Log(item.Name);
        }
    }
}
