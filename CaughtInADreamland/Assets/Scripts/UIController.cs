using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] Image life_one;
    [SerializeField] Image life_two;
    [SerializeField] Image life_three;
    [SerializeField] Image gem;
    [SerializeField] TextMeshProUGUI helperText;
    [SerializeField] CreatureSO creatureSO;

    private void Start() {
        switch(creatureSO.health) {
            case 1:
                setLifeOneAlpha(1f);
                setLifeTwoAlpha(0f);
                setLifeThreeAlpha(0f);
                break;
            case 2:
                setLifeOneAlpha(1f);
                setLifeTwoAlpha(1f);
                setLifeThreeAlpha(0f);
                break;
            case 3:
                setLifeOneAlpha(1f);
                setLifeTwoAlpha(1f);
                setLifeThreeAlpha(1f);
                break;
            default:
                Debug.LogWarning("Player health is outside the required boundary (1-3 inclusive). Player health = " + creatureSO.health);
                break;
        }
    }

    public void setLifeOneAlpha(float a = 0f, float t = 0f) {
        float timer = 0f;

        while(timer < t) {
            life_one.color = new Color(life_one.color.r, life_one.color.g, life_one.color.b, a*(t/timer));
        }

        life_one.color = new Color(life_one.color.r, life_one.color.g, life_one.color.b, a);
    }

    public void setLifeTwoAlpha(float a = 0f, float t = 0f) {
        float timer = 0f;

        while(timer < t) {
            life_two.color = new Color(life_two.color.r, life_two.color.g, life_two.color.b, a*(t/timer));
        }

        life_two.color = new Color(life_two.color.r, life_two.color.g, life_two.color.b, a);
    }

    public void setLifeThreeAlpha(float a = 0f, float t = 0f) {
        float timer = 0f;

        while(timer < t) {
            life_three.color = new Color(life_three.color.r, life_three.color.g, life_three.color.b, a*(t/timer));
        }

        life_three.color = new Color(life_three.color.r, life_three.color.g, life_three.color.b, a);
    }
    public void setGemAlpha(float a = 0f) {
        gem.color = new Color(gem.color.r, gem.color.g, gem.color.b, a);
    }

    public void setHelperText(string str = "") {
        helperText.text = str;
    }

}
