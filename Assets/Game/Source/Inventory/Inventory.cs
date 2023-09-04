using System;
using System.Collections.Generic;
using System.Linq;
using Json;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Source.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField , InterfaceType(typeof(IInventoryRenderer))] private Object _object;
        private IInventoryRenderer _renderer {get{return _object as IInventoryRenderer;}}
        [SerializeField] private int _amountOfCalls;
        
        private List<IInventorySlot> _slots;
        private readonly string _path =  Application.persistentDataPath + "/InventroyData.json";
        
        public Action<int, IVeiwInventorySlot> IsSlotUpdate;


        public void Initialize()
        {
           var inventoryData = JsonSavingSystem<IInventorySlot>.LoadList(_path);

           if (inventoryData != null)
           {
               _slots = inventoryData;
           }
           else
           { 
               for (int i = 0; i < _amountOfCalls; i++)
               {
                   _slots.Add(new InventorySlot(i));
                   _slots[i].IsItemUpdate += IsSlotUpdate;
               }
           }
           _renderer.Render((List<IVeiwInventorySlot>)_slots.Cast<IVeiwInventorySlot>());
           IsSlotUpdate += _renderer.UpdateSlot;
        }
        
        public void Remove(Type iteamType , int amountToReamove = 1)
        {
            var slotWithFindIteams = GetAllByType(iteamType);
            if (slotWithFindIteams.Count == 0)
                return;
            
            var countOfFindItem = slotWithFindIteams.Count;

            for (int i = 0; i < slotWithFindIteams.Count; i--)
            {
                var slot = slotWithFindIteams[i];
                if (slot.Amount >= amountToReamove)
                {
                    slot.ReduceNumber(amountToReamove);
                    
                    if(slot.Amount <= 0) 
                        slot.Clear();
                    
                    continue;
                }

                var amountToRemove = slot.Amount;
                amountToReamove -= slot.Amount;
                slot.Clear();
            }
        }

        public bool TryAdd(IItem item ,int slotIndex, int amount = 1 )
        {
            if (_slots.Count < slotIndex || HasFreeSlots())
                return false;
            
            
            if (_slots[slotIndex].IsEmpty == false)
            {
                if (_slots[slotIndex].IteamType == item.Type)
                {
                    _slots[slotIndex].IncreaseNumber(amount);
                }
                else
                {
                    var swapingIteam = _slots[slotIndex].Item;
                    _slots[slotIndex].SetIteam(item);
                    item.Swap?.Invoke(swapingIteam);
                }
            }
            else
            {
                _slots[slotIndex].SetIteam(item);
            }
            return true;
        }

        public bool HasIteam(Type desiredIteamType)
        {
            if (_slots.Find(slot => !slot.IsEmpty && slot.IteamType == desiredIteamType) != null)
            {
                return true;
            }

            return false;
        }

        public List<IInventorySlot> GetInventory()
        {
            return _slots;
        }
        
        private List<IInventorySlot> GetAllByType(Type iteamType)
        {
            return _slots.FindAll(slot => !slot.IsEmpty && slot.IteamType == iteamType);
        }

        private bool HasFreeSlots()
        {
            if(_slots.Find(slot => slot.IsEmpty) != null)
            {
                return true;
            }
            return false;
        }
    }
}