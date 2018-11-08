﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveTimerUI : MonoBehaviour {

	public Text TextField;
	public float TimeUntilWarning;
    public float remainingTime;
    public bool isCountingDown = false;

	public void StartCountdown(float duration) {      
        remainingTime = TimeUntilWarning;
        StartCoroutine(waitAndDisplayWarning(duration));               
	}
    
	private IEnumerator waitAndDisplayWarning(float duration) {
		yield return new WaitForSeconds(duration - TimeUntilWarning);
        isCountingDown = true;        
	}

    private void Update() {
        if (isCountingDown) {
            TextField.text = remainingTime.ToString("0");
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0f) {
                TextField.text = "";
                StartCoroutine(DisplayFight());
                isCountingDown = false;
            }
        }
    }

    private IEnumerator DisplayFight() {
		TextField.text = "Fight!";
		StartCoroutine(waitAndEraseText(1.5f));
        yield break;
	}

    public IEnumerator DisplayEndRound() {
        Debug.Log("Wave completed");
        TextField.text = "Round Complete!";
        StartCoroutine(waitAndEraseText(2.0f));
        //TextField.text = "Prepare your defensive for the next wave!";
        //StartCoroutine(waitAndEraseText(1.5f));
        yield break;
    }

    private IEnumerator waitAndEraseText(float duration) {
		yield return new WaitForSeconds(duration);
		TextField.text = "";
	}
}
