using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCreator : MonoBehaviour
{
    [SerializeField] private GameObject buttonPreFab;
    [SerializeField] private Transform buttonContainer;
    [SerializeField] private Sprite lockIcon;

    private void Start()
    {
        StartCoroutine(CreateInventory());
    }

    IEnumerator CreateInventory()
    {
        yield return new WaitForEndOfFrame();

        foreach(Item item in ItemManager.Instance.Items)
        {
            GameObject instance = Instantiate(buttonPreFab, buttonContainer);
            instance.name = item.name;
            InventoryItem inventoryItem = instance.GetComponent<InventoryItem>();
            inventoryItem.Item = item;

            inventoryItem.Renderer.sprite = item.Icon;
        }
    }
}
