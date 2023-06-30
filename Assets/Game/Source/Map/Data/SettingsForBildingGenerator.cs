using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "BildingSettingsForGenerator" , menuName = "ScriptableObjects/MapGenerator/BildingSettingsForGenerator")]
    public class SettingsForBildingGenerator : ScriptableObject
    {
        [field: SerializeField] public List<BuildingSettingsForSpawn> CompulsoryBuildings { get; private set; }
        [field: SerializeField] public List<BuildingSettingsForSpawn> Dunges { get; private set; }
        [SerializeField] private int MinCountDungee;
        [SerializeField] private int MaxCountDungee;
        
        public int CountOfDungee { get { return Random.Range(MinCountDungee, MaxCountDungee); } }
    }
}