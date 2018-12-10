using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MatchManager : MonoBehaviour
{
	public event Action MatchStarted;

	private const int matchCountdownInSeconds = 5;
	private int secondsUntilMatchStart;	
	public int SecondsUntilMatchStart {get {return secondsUntilMatchStart;}}

	private void Start()
	{
		GameManager.Instance.NetworkManager.FilledRoom += BeginMatchCountdownToStart;

		secondsUntilMatchStart = matchCountdownInSeconds;
	}	

	private void BeginMatchCountdownToStart()
	{
		StartCoroutine(MatchCountdown());
	}

	IEnumerator MatchCountdown()
	{
		while(secondsUntilMatchStart > 0)
		{
			yield return new WaitForSeconds(1.0f);
			secondsUntilMatchStart -= 1;
			GameManager.Instance.UIManager.GameMessage.ShowGameMessage("Match Starts in " + (secondsUntilMatchStart + 1).ToString());
		}

		MatchStarted();
	}
}
