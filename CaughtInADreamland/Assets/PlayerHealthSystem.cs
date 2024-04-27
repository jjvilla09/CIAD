using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour, IHealthSystem<int>
{
    [SerializeField] AudioSource deathSFXAudioSource;
    [SerializeField] AudioClip deathSFXClip;
    [SerializeField] UIController uiController;
    [SerializeField] FadeTransitionController ftc;
    [SerializeField] string GameOverSceneName = "GameOver";
    [SerializeField] float dimHealthValue = 0f;
    //[SerializeField] float timeToDim = 1f;
    //string type = "Player";

    // got this code from https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/interface-properties
    private int _health;
    public int health {
        get => _health;
        set => _health = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _health = 3; // start with three health
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHealth(int val = 1) {
        switch(_health) {
            case 1: 
                uiController.setLifeTwoAlpha(1f);
                _health += 1;
                break;
            case 2: 
                uiController.setLifeThreeAlpha(1f);
                _health += 1;
                break;
            default: 
                Debug.Log("Lives: " + _health);
                break;
        }
    }

    public void SubtractHealth(int val = 1) {
        deathSFXAudioSource.PlayOneShot(deathSFXClip);
        switch(_health) {
            case 1: 
                uiController.setLifeOneAlpha(dimHealthValue);
                ftc.FadeToColor(GameOverSceneName); // change to 'game over' scene
                break;
            case 2: 
                uiController.setLifeTwoAlpha(dimHealthValue);
                _health -= 1;
                break;
            case 3: 
                uiController.setLifeThreeAlpha(dimHealthValue);
                _health -= 1;
                break;
            default: 
                Debug.Log("Lives: " + _health);
                break;
        }
    }
}
