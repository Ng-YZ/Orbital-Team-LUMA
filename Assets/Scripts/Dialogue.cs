using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//https://www.youtube.com/watch?v=JfyWgJBShak 31:48
public class Dialogue : MonoBehaviour
{
    //fields
    //window
    public GameObject window;
    //indicator
    public GameObject indicator;
    //text component
    public TMP_Text dialogueText;
    //writing speed
    public float writingSpeed;
    //dialogues list
    public List<string> dialogues;
    //index on dialogues
    private int index;
    //character index
    private int charIndex;
    //start boolean
    private bool started;
    //wait for next
    private bool waitForNext;

    private void ToggleWindow(bool show) 
    {
        window.SetActive(show);
    }
    
    private void ToggleIndicator(bool show) 
    {
        indicator.SetActive(show);
    }

    //start dialogue
    public void StartDialogue() {
        if(started) {
            return;
        }

        //indicate start of dialogue
        started = true;
        //show window
        ToggleWindow(true);
        //hide indicator
        ToggleIndicator(false);
        //start dialogue
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        //start index at 0
        index = i;
        //reset char index
        charIndex = 0;
        //clear dialogue component text
        dialogueText.text = string.Empty;
        StartCoroutine(Writing());
    }

    //end dialogue
    public void EndDialogue() {
        //hide window  
        ToggleWindow(false);
    }

    //writing logic
    IEnumerator Writing() {
        string currentDialogue = dialogues[index];
        //write the character
        dialogueText.text += currentDialogue[charIndex];
        //increase char index
        charIndex++;
        //check if end of sentence
        if(charIndex < currentDialogue.Length) {
            //start from index 0
            //wait x seconds
            yield return new WaitForSeconds(writingSpeed);
            //restart process
            StartCoroutine(Writing());
        } else {
            //end sentence.
            waitForNext = true;
        }
        
    }

    private void Update() {
        if (!started) {
            return;
        }

        if (waitForNext && Input.GetKeyDown(KeyCode.C)) {
            waitForNext = false;    
            index++;

            if(index < dialogues.Count) {
                GetDialogue(index);
            } else {
                EndDialogue();
            }
        }
    }

}
