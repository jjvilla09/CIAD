using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public enum DialogueState { Running, Waiting, Stopped }
    public DialogueState state;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] Canvas canvas;
    string sentence;

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
        sentence = s;
        StopAllCoroutines();
        
        StartCoroutine(RenderTextToScreen_TimedIntervalRoutine(t));
        IEnumerator RenderTextToScreen_TimedIntervalRoutine(float t) {
            string s_rendered = "";
            int sLen = s.Length;
            
            for(int i = 0; i < sLen; i++) {
                state = DialogueState.Running;
                s_rendered += s[i];
                dialogueText.text = s_rendered;
                yield return new WaitForSeconds(t);
            }
            state = DialogueState.Waiting;
        }
        
    }

    public void RenderTextToScreen(string s) {
        StopAllCoroutines();
        state = DialogueState.Waiting;
        dialogueText.text = s;
    }

    public void RenderTextToScreen_Skip() {
        StopAllCoroutines();
        state = DialogueState.Waiting;
        dialogueText.text = sentence;
    }

    public void OpenDialogueBillboard() {
        dialogueText.text = "";
        canvas.enabled = true;
    }

    public void CloseDialogueBillboard() {
        dialogueText.text = "";
        canvas.enabled = false;
        state = DialogueState.Stopped;
    }
}
