using UnityEngine;
using System.Collections;

public class PooledObject : MonoBehaviour {

	[System.NonSerialized]
	ObjectPool poolInstanceForPrefab;

	public ObjectPool objectPool {get; set;}

	public void ReturnToPool() {
		if (objectPool) {
			objectPool.AddObject (this);
		} else
			Destroy (gameObject);
	}

	public T GetPooledInstance<T> () where T : PooledObject {
		if (!poolInstanceForPrefab) {
			poolInstanceForPrefab = ObjectPool.GetPool (this);
		}
		return (T)poolInstanceForPrefab.GetObject ();
	}

	public void FillPool<T> (int amount) where T : PooledObject {
		if (!poolInstanceForPrefab) {
			poolInstanceForPrefab = ObjectPool.GetPool (this);
		}
		for(int i = 0; i < amount; i++ ) 
			poolInstanceForPrefab.CreateObject ();
	}

	public virtual void poolStart() {

	}
}
