using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI timerText;
	
	[Header("Timer settings")]
	public float currentTime;
	public bool countDown;
	
	[Header ("Limit Setting")]
	public bool hasLimit;
	public float timerLimit;
	
	[Header("FormatSettings")]
	public bool hasFormat;
	public TimerFormats formats;
	public Dictionary<TimerFormats, string> timerFormats = new Dictionary<TimerFormats, string>();
    // Start is called before the first frame update
    void Start()
    {
	    timerFormats.Add(TimerFormats.Whole, "0");
	    timerFormats.Add(TimerFormats.TenthDecimal, "0.0");
	    timerFormats.Add(TimerFormats.HundrathsDecimal, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
	    currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
	    
	    if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
	    {
	    	currentTime = timerLimit;
	    	SetTimerText();
	    	timerText.color = Color.red;
	    	enabled = false;
	    }
	    
	    SetTimerText();
    }
    
	private void SetTimerText()
	{
		timerText.text = hasFormat ? currentTime.ToString(timerFormats[formats]) : currentTime.ToString();
	}
}
public enum TimerFormats
{
	Whole,
	TenthDecimal,
	HundrathsDecimal
};