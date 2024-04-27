using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoulGrabber : MonoBehaviour
{
    public UnityEvent onSoulPickup;

    //this is how we can pass along data to functions through our events
    // [System.Serializable]
    // public class MyEvent : UnityEvent<int> {}
    // public MyEvent myPickupEvent;

    void Start(){
        onSoulPickup.AddListener(PrintPickup);
    }

    void PrintPickup(){
        //Debug.Log("Picked up soul!");
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<Soul>() != null){
            onSoulPickup.Invoke();
            //myPickupEvent.Invoke(42); //this is how we can pass along data to functions, select the dynamic option if doing so through inspector
            GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
    }
}
