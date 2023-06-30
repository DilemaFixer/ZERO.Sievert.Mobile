using System.Collections.Generic;
using Game.Source;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Map" , menuName = "ScriptableObjects/MapGenerator/Map")]
    public class MapSettings : ScriptableObject
    {
        [field: SerializeField] public SettingsForBildingGenerator SettingsForBildingGenerator { get; private set; }
        [field: SerializeField] public Transform SpawnPoint { get; private set; }
        [field: SerializeField] public int Width { get; private set; }
        [field: SerializeField] public int Height { get; private set; }
        [field: SerializeField] public float Scale { get; private set; }
        [field: SerializeField] public float TreeDensity { get; private set; }
        [field: Space]
        [field: SerializeField] public bool SpawnDecorGrass { get; private set; }
        [field: SerializeField] public bool SpawnLake { get; private set; }
        [field: SerializeField] public bool SpawnRoad { get; private set; }
        [field: SerializeField] public List<GameObject> Forest{ get; private set; }
        [field: SerializeField] public List<Block> Grass{ get; private set; }
        [field: SerializeField] public List<Block> Ground{ get; private set; }
        [field: SerializeField] public Block Lake{ get; private set; }
        [field: SerializeField] public GameObject RocksPrefab { get; private set; }
        
    }
}