using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour, IInteractable
{
    [SerializeField] UIController uic;
    [SerializeField] Shop shop;
    bool isPlayerInRange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ProximityCheck() {
        return isPlayerInRange;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            isPlayerInRange = false;
        }
    }

    public void ShowHelperText() {
        uic.setHelperText("Press E to Open Shop");
    }

    public void Interact() {
        shop.OpenShop();
    }

    public Vector3 GetPosition() {
        return this.gameObject.transform.position;
    }
}
