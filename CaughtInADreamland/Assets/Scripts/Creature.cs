using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [Header("Player Stats")]
    public float speed = 0f;
    int lives = 3;
    bool hasGem = false;
    Rigidbody2D rb;
    public GameObject body;

    [Header("Animation")]
    [SerializeField] List<AnimationStateController> animationStateControllers;

    [Header("UI")]
    [SerializeField] UIController uiController;

    [Header("Scene Changes")]
    [SerializeField] FadeTransitionController ftc;

    [Header("Audio")]
    [SerializeField] AudioSource SFXAudioSource;
    [SerializeField] AudioSource deathSFXAudioSource;
    [SerializeField] AudioSource gemPickupSFXAudioSource;
    [SerializeField] AudioClip deathSFXClip;
    [SerializeField] AudioClip gemPickupClip;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCreature(Vector3 direction) {
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

    public void setHasGem(bool tv) {
        hasGem = tv;
    }

    public bool getHasGem() {
        return this.hasGem;
    }

    public void SubtractLife() {
        deathSFXAudioSource.PlayOneShot(deathSFXClip);
        switch(lives) {
            case 1: 
                uiController.setLifeOneAlpha();
                ftc.FadeToColor("GameOver"); // change to 'game over' scene
                break;
            case 2: 
                uiController.setLifeTwoAlpha();
                lives -= 1;
                break;
            case 3: 
                uiController.setLifeThreeAlpha();
                lives -= 1;
                break;
            default: 
                Debug.Log("Lives: " + lives);
                break;
        }
        
    }

    public void AddLife() {
        switch(lives) {
            case 1: 
                uiController.setLifeTwoAlpha(1f);
                lives += 1;
                break;
            case 2: 
                uiController.setLifeThreeAlpha(1f);
                lives += 1;
                break;
            default: 
                Debug.Log("Lives: " + lives);
                break;
        }
        
    }

    public int GetLives() {
        return lives;
    }

    public void pickupGem() {
        gemPickupSFXAudioSource.PlayOneShot(gemPickupClip);
    }

    public void Stop(){
        MoveCreature(Vector3.zero);
    }

    public void MoveCreatureToward(Vector3 target){
        Vector3 direction = target - transform.position;
        MoveCreature(direction.normalized);
    }
}
