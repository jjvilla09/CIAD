using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] float speed;
    int lives = 3;
    bool hasGem = false;
    Rigidbody2D rb;
    [SerializeField] GameObject body;
    [SerializeField] List<AnimationStateController> animationStateControllers;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void movePlayer(Vector3 direction) {
        // Change speed
        rb.velocity = direction * speed;

        // Change direction
        if(rb.velocity.x > 0) {
            body.transform.localScale = new Vector3(1, 1, 1);
        } else if (rb.velocity.x < 0) {
            body.transform.localScale = new Vector3(-1, 1, 1);
        }

        // Change animation
        if(rb.velocity.x == 0 && rb.velocity.y == 0) {
            foreach(AnimationStateController asc in animationStateControllers) {
                asc.ChangeAnimationState("JayIdle");
            } 
        } else {
            foreach(AnimationStateController asc in animationStateControllers) {
                asc.ChangeAnimationState("JayWalk-East");
            } 
        }
    }

    public void setHasGemTrue() {
        hasGem = true;
    }
    public void setHasGemFalse() {
        hasGem = false;
    }
}
