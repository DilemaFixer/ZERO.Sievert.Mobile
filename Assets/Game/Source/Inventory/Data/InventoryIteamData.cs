using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Source.Inventory
{
    [CreateAssetMenu(fileName = "InventoryItemData", menuName = "ScriptableObject/Inventory/InventoryIteamData", order = 0)]
    public class InventoryIteamData : ScriptableObject
    {
        [field: SerializeField] public int MaxCountInCall { get; private set; }
        [field: SerializeField] public Image Icon { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
    }
}