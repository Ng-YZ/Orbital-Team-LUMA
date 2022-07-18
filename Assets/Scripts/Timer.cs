using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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


    // Start is called before the first frame update
    //Adds dropdown to choose between 0dp, 1dp and 2dp
    void Start()
    {
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimerFormats.HundrethsDecimal, "0.00");
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive) {
            currentTime = countDown ? currentTime - Time.deltaTime : currentTime + Time.deltaTime;
        } else if (!timerActive) {
            currentTime -= Time.deltaTime;
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
        // if this current time > previous saved timings, then setFloat again
        PlayerPrefs.SetFloat("Record", Time.time);
    }
}

public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundrethsDecimal
}