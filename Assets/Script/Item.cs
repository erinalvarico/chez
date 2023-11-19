using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObject/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public string Id;
    public Sprite Icon;
    public bool IsLocked;
    public int UpgradeLevel;
}
