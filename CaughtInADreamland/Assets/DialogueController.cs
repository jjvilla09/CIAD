using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] Canvas canvas;

    // Start is called before the first frame update
    void Awake()
    {
        CloseDialogueBillboard();
    }

    void Start() {

    }

    // void Update() {
    //     if(Input.GetKeyDown(KeyCode.T)) {
    //         RenderTextToScreen_TimedInterval(tInterval, "hello");
    //     }
    //     if(Input.GetKeyDown(KeyCode.V)) {
    //         OpenDialogueBillboard();
    //     }
    //     if(Input.GetKeyDown(KeyCode.B)) {
    //         CloseDialogueBillboard();
    //     }
    // }

    public void RenderTextToScreen_TimedInterval(string s, float t = .05f) {
        StopAllCoroutines();
        StartCoroutine(RenderTextToScreen_TimedIntervalRoutine(t));
        
        IEnumerator RenderTextToScreen_TimedIntervalRoutine(float t){
            string s_rendered = "";
            int sLen = s.Length;
            
            for(int i = 0; i < sLen; i++) {
                s_rendered += s[i];
                dialogueText.text = s_rendered;
                yield return new WaitForSeconds(t);
            }
            
        }
        
    }

    public void RenderTextToScreen(string s) {
        StopAllCoroutines();
        dialogueText.text = s;
    }

    public void OpenDialogueBillboard() {
        dialogueText.text = "";
        canvas.enabled = true;
    }

    public void CloseDialogueBillboard() {
        dialogueText.text = "";
        canvas.enabled = false;
    }
}
