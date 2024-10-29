using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<ItemInfos> spawnablePrefab;
    public List<ItemInfos> spawnablePrefabTemp = new List<ItemInfos>();
    [SerializeField] List<Transform> spawners;

    public static SpawnManager instance;

    private void Awake()
    {
        instance = this;

    }


    // Start is called before the first frame update
    void Start()
    {
        SpawnAllEssentialItems();
        SpawnAllNonEssentialItems();
    }

    void GetAllSpawners()
    {
        spawners = new List<Transform>();
        foreach (Transform t in transform)
            spawners.Add(t);
    }

    void SpawnAllEssentialItems()
    {
        GetAllSpawners();
        GetAllEssentialItems();
        foreach (Transform t in spawners)
        {
            ItemInfos item = GetRandomItem(spawnablePrefabTemp);
            if (item == null) break;
            SpawnItem(item, t);
            t.parent = null;
        }
        foreach (Transform t in spawners)
            Destroy(t.gameObject);
    }

    void GetAllEssentialItems()
    {
        spawnablePrefabTemp.Clear();
        foreach (var item in spawnablePrefab)
        {
            if (item.IsEssential && !item.MinimumCountReached)
            {

                for (int i = 0; i < item.minSpawnCount; i++)
                    spawnablePrefabTemp.Add(item);
            }
        }
    }

    public void GetAllNonEssentialItems()
    {
        spawnablePrefabTemp.Clear();
        foreach (var item in spawnablePrefab)
        {
            if (!item.IsSpawnable) continue;
            spawnablePrefabTemp.Add(item);
        }
    }

    void SpawnAllNonEssentialItems()
    {
        GetAllSpawners();
        GetAllNonEssentialItems();
        foreach (Transform t in spawners)
        {
            ItemInfos item = GetRandomItem(spawnablePrefabTemp);
            if (item == null) break;
            SpawnItem(item, t);
            t.parent = null;
        }
        foreach (Transform t in spawners)
            Destroy(t.gameObject);
    }

    ItemInfos GetRandomItem(List<ItemInfos>items)
    {
        if (items.Count == 0) return null;
        int index = UnityEngine.Random.Range(0, items.Count); //on tire un nombre aléatoire compris entre 0 et la taille de la liste -1. On assigne le résultat dans index.
        ItemInfos item = items[index];
        items.RemoveAt(index);
        return item;
        
    }

    void SpawnItem(ItemInfos item, Transform spawner)
    {
        if (item == null) return;
        GameObject coinInstance = Instantiate(item.prefab);
        item.spawnCount++;
        coinInstance.transform.position = spawner.position;
    }
}



[System.Serializable]
public class ItemInfos
{
    [Tooltip("Nombre maximum d'objet de ce type que doit comporter le niveau, si -1 pas de limite")]
    public int maxSpawnCount = -1;
    [Tooltip("Nombre minimum d'objet de ce type que doit comporter le niveau, si 0 n'est pas indispensable")]
    public int minSpawnCount = 1;

    //[System.NonSerialized]
    public int spawnCount = 0;
    public GameObject prefab;

    public bool IsSpawnable
    {
        get
        {
            if (maxSpawnCount == -1) return true;
            return spawnCount < maxSpawnCount;
        }
    }

    public bool IsEssential
    {
        get
        {
            return (minSpawnCount > 0);
        }
    }

    public bool MinimumCountReached
    {
        get
        {
            return spawnCount >= minSpawnCount;
        }
    }
}
