using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Map 
    {
        public Block[,] Land { get; private set; }
        public List<GameObject> DecorativeObjects { get; private set; }
        public List<GameObject> Buildings { get; private set; }

        public void SetLand(Block[,] Land)
        {
            if(Land == null)
                return;
            this.Land = Land;
        }

        public void SetDecorativeObjects(List<GameObject> DecorativeObjects)
        {
            if(DecorativeObjects == null)
                return;
            this.DecorativeObjects = DecorativeObjects;
        }

        public void SetBuildings(List<GameObject> Buildings)
        {
            if(Buildings == null)
                return;
            this.Buildings = Buildings;
        }
    }
}