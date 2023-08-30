using UnityEngine;

namespace Game
{
    public class Block : MonoBehaviour 
    {
        [SerializeField] private BlockStates _blockState;
        
        public bool IsBlocked { get; private set;}
        
        
        public BlockStates BlockState { get { return _blockState; } }

        public void SetNotAvailable() => _blockState = BlockStates.NotAvailable;
        
        public void BlockNode()
        {
            IsBlocked = false;
        }
        
    }

    public enum BlockStates
    {
        Available ,
        NotAvailable
    }
}