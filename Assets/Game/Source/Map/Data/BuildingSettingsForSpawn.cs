using Game.Source;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "BildingSettings" , menuName = "ScriptableObjects/MapGenerator/BildingSettings")]
    public class BuildingSettingsForSpawn : ScriptableObject
    {
        [field: SerializeField] public int Width { get; private set; }
        [field: SerializeField] public int Height { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}