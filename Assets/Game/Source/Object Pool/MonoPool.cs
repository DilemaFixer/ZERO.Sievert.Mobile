using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Object_Pool
{
    public class MonoPool<T> : IPool<T> where T : MonoBehaviour, IPoolable<T>
    {
        private T _prefab;
        private int _maxCountObjInPool;
        private bool _isPossibleExpenses;
        private Transform _container;
        private Action<T> _pullObject;
        private Action<T> _pushObject;

        private List<T> _pool;

        public int PoolCount
        {
            get
            {
                return _pool.Count;
            }
        }

        public MonoPool(T Prefab, int MaxCountObjInPool,  bool IsPossibleExpenses,
         Transform Container = null)
        { 
          _prefab = Prefab;
          _maxCountObjInPool = MaxCountObjInPool;
          _container = Container;
          _isPossibleExpenses = IsPossibleExpenses;
           CreatePool();
        }

        private void CreatePool()
        {
            _pool = new List<T>();
            for (int i = 0; i < _maxCountObjInPool; i++)
            {
                CreateObj();
            }
        }

        private T CreateObj( bool IsActiveByDefault = false)
        {
            var createdObj = Object.Instantiate(_prefab, _container);
            createdObj.SetActivity(IsActiveByDefault);
            createdObj.Initialize(Push);
            _pool.Add(createdObj);
            return createdObj;
        }
        
       public T Pull()
       {
           T element;
           if (HasFreeElement(out element))
           {
               element.SetActivity(true);
           }
           else if (_pool.Count < _maxCountObjInPool || _isPossibleExpenses)
           {
               element = CreateObj(true);
           }
           else
           {
               throw new NullReferenceException("No free elements in the pool.");
           }
       
           _pullObject?.Invoke(element);
           return element;
       }


        public void Push(T Item)
        {
            if (_pool.Count >= _maxCountObjInPool)
            {
                _pool.Remove(Item);
                Object.Destroy(Item.gameObject);
            }
            else
            {
                _pool.Add(Item);
            }

            _pushObject?.Invoke(Item);
            Item.SetActivity(false);
        }

        public bool HasFreeElement(out T Element)
        {
            foreach (var obj in _pool)
            {
                if (obj.Activity)
                {
                    Element = obj;
                    obj.SetActivity(false);
                    return true;
                }
            }

            Element = null;
            return false;
        }

        public void AddExternalObjectProcessing(Action<T> PullObject ,  Action<T> PushObject)
        {
            _pullObject = PullObject;
            _pushObject = PushObject;
        } 
        /*
         * public void TestPull(Acti)
         */
    }
}