using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//referenced from: https://www.youtube.com/watch?v=JfyWgJBShak
public class Dialogue : MonoBehaviour
{
    public GameObject window;
    public GameObject indicator;

    public TMP_Text dialogueText;

    public float writingSpeed;
    //dialogues list
    public List<string> dialogues;
    //index on dialogues
    private int index;
    //character index
    private int charIndex;

    private bool started;
    private bool waitForNext;

    private void Awake() 
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }

    private void ToggleWindow(bool show) 
    {
        window.SetActive(show);
    }
    
    public void ToggleIndicator(bool show) 
    {
        indicator.SetActive(show);
    }

    public void StartDialogue() 
    {
        if(started) 
        {
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
        //start index always at 0
        index = i;
        //reset char index
        charIndex = 0;
        //clear dialogue component text
        dialogueText.text = string.Empty;
        StartCoroutine(Writing());
    }

    public void EndDialogue() 
    {
        started = false;
        waitForNext = false;
        StopAllCoroutines();
        
        //hide window  
        ToggleWindow(false);
    }

    //writing logic
    IEnumerator Writing() 
    {    
        yield return new WaitForSeconds(writingSpeed); //new line added

        string currentDialogue = dialogues[index];
        //write the character
        dialogueText.text += currentDialogue[charIndex];
        //increase character index
        charIndex++;
        //check if end of sentence
        if(charIndex < currentDialogue.Length) 
        {
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
        if (!started) 
        {
            return;
        }

        if (waitForNext && Input.GetKeyDown(KeyCode.E)) 
        {
            waitForNext = false;    
            index++;

            if(index < dialogues.Count) {
                GetDialogue(index);
            } else {
                ToggleIndicator(true);
                EndDialogue();
            }
        }
    }

}
