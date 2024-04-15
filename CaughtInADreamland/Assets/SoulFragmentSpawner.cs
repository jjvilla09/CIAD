using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFragmentSpawner : MonoBehaviour
{
    [Header("Soul Reference Object")]
    [SerializeField] GameObject soulFragment;
    List<GameObject> newSoulFragmentList;
    
    GameObject newSoulFragment;
    Rigidbody2D newSoulRB;

    [Header("Float Animation Values")]
    [SerializeField] float thrust = 1f;
    [SerializeField] float gscale = 0.5f;
    [SerializeField] float animationTime = 3f;
    [SerializeField] float destroySoulTimer = 25f;

    [Header("Spawn Statistics")]
    [SerializeField] float spawnRate;
    [SerializeField] int rMin, rMax;
    Vector3 offset = Vector3.zero;

    void Start()
    {
        // initialize list of soul frag game objects
        if(newSoulFragmentList == null) {
            newSoulFragmentList = new List<GameObject>();
        }
    }

    void Update() 
    {
        
    }

    GameObject spawnSoul() {
        return Instantiate(soulFragment, transform.position, Quaternion.identity);

    }

    void SpawnSoulWithForce() {
        // spawn soul
        newSoulFragment = spawnSoul();
        Destroy(newSoulFragment, destroySoulTimer);

        // start 'float' animation
        newSoulFragment.GetComponent<Soul>().FloatAnimation(animationTime, gscale, thrust);
    }

    public int SpawnSoulWithForce_TimedInterval() {
        int cnt = 0;
        int r = Random.Range(rMin, rMax);
        StartCoroutine(SpawnSoulWithForce_TimedIntervalRoutine());
        IEnumerator SpawnSoulWithForce_TimedIntervalRoutine() {
            for(cnt = 0; cnt < r; cnt++) {
                SpawnSoulWithForce();
                yield return new WaitForSeconds(1/spawnRate);
            }
        }
        return r;
    }
}
