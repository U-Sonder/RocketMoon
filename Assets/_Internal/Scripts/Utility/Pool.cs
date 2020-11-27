using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> : MonoBehaviour where T : Component
{
    [Header("Pool properties")]
    [SerializeField] protected T prefab;
    [SerializeField] protected Transform parent;
    [SerializeField] private int poolAmount = 10;

    private PoolObjectSpawner<T> spawner;
    private List<T> objectsList;

    protected virtual void Awake()
    {
        spawner = new PoolObjectSpawner<T>(prefab, parent);
        objectsList = new List<T>(poolAmount);
        for (int i = 0; i < poolAmount; i++)
        {
            var instance = spawner.Spawn(parent.position, parent.rotation);
            objectsList.Add(instance);
        }
    }

    protected T Spawn(Vector3 position, Quaternion rotation)
    {
        foreach (var obj in objectsList)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                return obj;
            }
        }
        return spawner.Spawn(position, rotation);
    }

    protected T Spawn()
    {
        return Spawn(parent.position, parent.rotation);
    }
}

public class PoolObjectSpawner<T> where T : Component
{
    private T prefab;
    private Transform parent;

    public PoolObjectSpawner(T prefab, Transform parent)
    {
        this.prefab = prefab;
        this.parent = parent;
        prefab.gameObject.SetActive(false);
    }

    public T Spawn(Vector3 position, Quaternion rotation)
    {
        return UnityEngine.Object.Instantiate(prefab, position, rotation, parent);
    }
}