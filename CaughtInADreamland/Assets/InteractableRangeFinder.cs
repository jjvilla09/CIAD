using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableRangeFinder : MonoBehaviour
{
    [SerializeField] Creature jay;
    List<IInteractable> InteractablesList; // Holds all IInteractable objects in the scene
    //[SerializeField] List<GameObject> ObjectInteractablesList;
    List<IInteractable> ActiveInteractablesList; // Holds the IInteractable objects that are in range of the player
    List<float> ActiveInteractablesDisplacementsList; // Holds the IInteractable objects displacements
    public IInteractable closestInteractable; // Holds the closest IInteractable object to the player
    float currentSmallestDisplacement;
    bool activeInteractableFlag; // Flag indicates there are one or more objects in range of the player
    public static InteractableRangeFinder singleton;

    void Awake() {
        if(singleton != null){
            Destroy(this.gameObject);
        }
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initializing Lists //
        if(InteractablesList == null) {
            InteractablesList = new List<IInteractable>();
        }

        if(ActiveInteractablesList == null) {
            ActiveInteractablesList = new List<IInteractable>();
        }

        if(ActiveInteractablesDisplacementsList == null) {
            ActiveInteractablesDisplacementsList = new List<float>();
        }
        // ------------------ //

        // This code was referenced from https://learn.unity.com/tutorial/interfaces# //
        MonoBehaviour[] allScripts = FindObjectsOfType<MonoBehaviour>();
        for (int i = 0; i < allScripts.Length; i++)
        {
            if(allScripts[i] is IInteractable)
                InteractablesList.Add(allScripts[i] as IInteractable);
        }
        // -------------------------------------------------------------------------- //
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    void ResetVariables() {
        activeInteractableFlag = false;
        ActiveInteractablesList.Clear();
        ActiveInteractablesDisplacementsList.Clear();
        currentSmallestDisplacement = Mathf.Infinity;
    }

    void AddInRangeObjectsToActiveList() {
        foreach(IInteractable i in InteractablesList) { // Add IInteractable object to active list if player is in range 
            if(i.ProximityCheck()) {                    // and store displacement float in list
                activeInteractableFlag = true;
                ActiveInteractablesList.Add(i);
                ActiveInteractablesDisplacementsList.Add(Vector3.Distance(jay.transform.position, i.GetPosition()));
                //Debug.DrawLine(jay.transform.position, i.GetPosition());
            }
        }
    }

    void GetClosestInteractableFromActiveList() {
        int listCount = ActiveInteractablesList.Count;

        if(listCount == 1) {                                    // if the player is in range of one object,
            closestInteractable = ActiveInteractablesList[0];   // make that object the closest interactable

        } else if(listCount > 1) {                              // if the player is in range of more than one interactable object,  
            for(int i = 0; i < listCount; i++) {                // make only the closest one interactable
                if(ActiveInteractablesDisplacementsList[i] < currentSmallestDisplacement) {
                    closestInteractable = ActiveInteractablesList[i];
                    currentSmallestDisplacement = ActiveInteractablesDisplacementsList[i];
                }
            }
        }
    }

    // Wrapper function
    public void GetClosestInteractableAndUpdateActiveDisplacements() {
        ResetVariables();
        AddInRangeObjectsToActiveList();
        GetClosestInteractableFromActiveList();
    }

    public bool GetActiveFlag() {
        return activeInteractableFlag;
    }
}
