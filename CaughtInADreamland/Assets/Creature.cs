using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] float speed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void movePlayer(Vector3 direction) {
        rb.velocity = direction * speed;
        //transform.position += direction * speed * Time.deltaTime;
        updatePlayerDirection(direction);
    }

    void updatePlayerDirection(Vector3 direction) {
        if(direction.x == 1) {
            transform.localScale = new Vector3(1, 1, 1);
            
        } 
        if(direction.x == -1) {
            transform.localScale = new Vector3(-1, 1, 1); 
        } 
    }
}
