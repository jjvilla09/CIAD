using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFragmentSpawner : MonoBehaviour
{
    [SerializeField] GameObject soulFragment;
    List<GameObject> newSoulFragmentList;
    
    GameObject newSoulFragment;
    Rigidbody2D newSoulRB;
    [SerializeField] float thrust = 1f;
    [SerializeField] float gscale = 0.5f;
    [SerializeField] float animationTime = 1000f;
    float destroySoulTimer = 25f;
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

    void SpawnSoulWithForce(){
        StartCoroutine(SpawnSoulWithForceRoutine());
        IEnumerator SpawnSoulWithForceRoutine(){
            float time = 0f;

            // spawn soul
            newSoulFragment = spawnSoul();
            Destroy(newSoulFragment, destroySoulTimer);
            newSoulRB = newSoulFragment.GetComponent<Rigidbody2D>();

            if(newSoulRB != null) {
                // add force to soul with gravity
                newSoulRB.AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 0), 0f) * thrust, ForceMode2D.Impulse);
                newSoulRB.gravityScale = gscale;
            }

            // wait some number of seconds
            while (time < animationTime) {
                yield return null;
                time += Time.deltaTime;
            }
            
            if(newSoulRB != null) {
                // remove gravity and forces
                newSoulRB.gravityScale = 0f;
                newSoulRB.velocity = Vector2.zero;
            }
        }
    }

    public int SpawnSoulWithForce_TimedInterval(float tInterval = 1f, int rMin = 1, int rMax = 1) {
        int cnt = 0;
        int r = Random.Range(rMin, rMax);
        StartCoroutine(SpawnSoulWithForce_TimedIntervalRoutine());
        IEnumerator SpawnSoulWithForce_TimedIntervalRoutine() {
            for(cnt = 0; cnt < r; cnt++) {
                SpawnSoulWithForce();
                yield return new WaitForSeconds(tInterval);
            }
        }
        return r;
    }
}
