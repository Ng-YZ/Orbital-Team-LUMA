using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    [Header("Component")]
    public TextMeshProUGUI timerText;


    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown; //if countDown is false, then the count is increasing

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();

    bool timerActive = false;

    private Scene scene;


    // Start is called before the first frame update
    //Adds dropdown to choose between 0dp, 1dp and 2dp
    void Start()
    {
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimerFormats.HundrethsDecimal, "0.00");
        timerActive = true;
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive) {
            //currentTime = countDown ? currentTime - Time.deltaTime : currentTime + Time.deltaTime;
            currentTime = Time.timeSinceLevelLoad;
        } 

        //sets limit for timer when "Has Limit box is checked in TimerManager
        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red; //adjusts colour of text
            enabled = false;
        }
        
        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();
    }

    public static void StopTimer() {
        Timer newObj = new Timer();
        newObj.timerActive = false;
        //check for scene name (using empty game object) + if this current time < previous saved timings, then update value
        if (GameObject.Find("ChangiName") == true && (Time.timeSinceLevelLoad < PlayerPrefs.GetFloat("Timing L1"))) 
        {
            PlayerPrefs.SetFloat("Timing L1", Time.timeSinceLevelLoad);    
        } else if (GameObject.Find("GBTBName") == true && (Time.timeSinceLevelLoad < PlayerPrefs.GetFloat("Timing L2"))) 
        {
            PlayerPrefs.SetFloat("Timing L2", Time.timeSinceLevelLoad);
        } else if (GameObject.Find("SentosaName") == true && (Time.timeSinceLevelLoad < PlayerPrefs.GetFloat("Timing L3"))) 
        {
            PlayerPrefs.SetFloat("Timing L3", Time.timeSinceLevelLoad);
        } else if (GameObject.Find("HeritageName") == true && (Time.timeSinceLevelLoad < PlayerPrefs.GetFloat("Timing L4"))) 
        {
            PlayerPrefs.SetFloat("Timing L4", Time.timeSinceLevelLoad);
        }
    }
}

public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundrethsDecimal
}