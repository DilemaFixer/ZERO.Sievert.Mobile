using UnityEngine;

namespace Game
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private BlockStates _blockState;
        public BlockStates BlockState { get { return _blockState; } }

        public void SetNotAvailable() => _blockState = BlockStates.NotAvailable;
    }

    public enum BlockStates
    {
        Available ,
        NotAvailable
    }
}