using System.Collections;
using System.Collections.Generic;
using Zenject;
using UnityEngine;
using WLF;

using ResourcePath = System.String;
using ObjectPool = System.Collections.Generic.List<UnityEngine.GameObject>;

namespace WLF {

    public class Pooler: MonoBehaviour {
        public static Pooler Instance = null;

        public static ObjectPool METEOR = null;

        void Awake() {
            if (Pooler.Instance != null) {
                Debug.LogError("Pooler already initialized");

            } else if (Pooler.Instance == null) {
                Pooler.Instance = this;
                initlializePooler();
            }
        }

        private void initlializePooler() {
            Pooler.METEOR = createPool(PrefabDatabase.METOER, 100);
        }

        private ObjectPool createPool(ResourcePath path, int count)
        {
            GameObject loadedObject = Resources.Load(path) as GameObject;
            ObjectPool pooledObjects = new List<GameObject>();
            for (int i = 0; i < count; i++)
            {
                GameObject pooledObject = Instantiate(loadedObject);
                pooledObject.SetActive(false);
                pooledObjects.Add(pooledObject);
            }
            return pooledObjects;

        }

        public static GameObject getObjectFromPool(ObjectPool pool)
        {
            foreach (GameObject poolObject in pool) {
                if (!poolObject.activeInHierarchy) {
                    return poolObject;
                }
            }

            return null;
        }

        public static void returnObjectToPool(GameObject pooledObject)
        {
            pooledObject.SetActive(false);
        }

    }
}
