using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Source
{
    public class ScenLoader : MonoBehaviour
    {
        [SerializeField] private int _scenIndex;
        
        public void LoadScenWithMapIndex(int MapIndex)
        {
            SceneData.MapIndex = MapIndex;
            SceneManager.LoadScene(_scenIndex);
        }

        public void LoadScen()
        {
            SceneManager.LoadScene(_scenIndex);
        }
    }
}