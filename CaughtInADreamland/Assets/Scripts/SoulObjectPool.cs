using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulObjectPool : MonoBehaviour
{
    [SerializeField] GameObject soulPrefab;
    List<GameObject> pooledSoulObjects;
    const int maxListSize = 50;

    // Start is called before the first frame update
    void Start()
    {
        if(pooledSoulObjects == null) {
            pooledSoulObjects = new List<GameObject>();
        }
    }

    public GameObject GetPooledSoul(Vector3 position, bool isActive = false) {
        if(pooledSoulObjects == null) {
            Debug.LogWarning("Pool must be instaniated.");
            return null;
        } else if(pooledSoulObjects.Count < maxListSize) {
            GameObject newSoul = Instantiate(soulPrefab, position, Quaternion.identity);

            newSoul.SetActive(isActive);
            pooledSoulObjects.Add(newSoul);

            return newSoul;
        }

        GameObject soul = pooledSoulObjects[0];
        pooledSoulObjects.RemoveAt(0);

        soul.transform.position = position;
        soul.SetActive(isActive);

        pooledSoulObjects.Add(soul);
        return soul;
    }

    public void AddSoulToFrontOfList(GameObject soul) {
        if(!pooledSoulObjects.Contains(soul) && pooledSoulObjects.Count >= maxListSize) {
            Destroy(soul);
        }
        
        soul.SetActive(false);
        pooledSoulObjects.Insert(0, soul);
    }
}
