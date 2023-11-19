using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour
{
    public Button UpgradeButton;
    public SpriteRenderer Renderer;
    public TextMeshProUGUI QuantityText;
    [HideInInspector] public Item Item;
}
