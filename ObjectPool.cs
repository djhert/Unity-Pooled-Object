using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

	PooledObject prefab;

	List<PooledObject> availableObject = new List<PooledObject> ();

	public PooledObject GetObject() {
		PooledObject obj;
		int lastAvailableIndex = availableObject.Count - 1;
		if (lastAvailableIndex >= 0) {
			obj = availableObject [lastAvailableIndex];
			availableObject.RemoveAt (lastAvailableIndex);
			obj.gameObject.SetActive (true);
		} else {
			obj = Instantiate<PooledObject> (prefab);
			obj.transform.SetParent (transform, false);
			obj.objectPool = this;
		}
		obj.poolStart();
		return obj;

	}
	public void AddObject( PooledObject o ) {
		o.gameObject.SetActive (false);
		o.gameObject.SetParent(transform,false);
		availableObject.Add (o);
	}

	public static ObjectPool GetPool( PooledObject prefab ) {
		GameObject obj;
		ObjectPool pool; 
		if (Application.isEditor) {
			obj = GameObject.Find (prefab.name + " Pool");
			if (obj) {
				pool = obj.GetComponent<ObjectPool> ();
				if (pool) {
					return pool;
				}
			}
		}
		obj = new GameObject (prefab.name + " Pool");
		pool = obj.AddComponent<ObjectPool> ();
		pool.prefab = prefab;
		return pool;
	}

	public void CreateObject() {
		PooledObject obj = Instantiate<PooledObject>(prefab);
		obj.transform.SetParent(transform,false);
		obj.objectPool = this;
		AddObject (obj);
	}
}
