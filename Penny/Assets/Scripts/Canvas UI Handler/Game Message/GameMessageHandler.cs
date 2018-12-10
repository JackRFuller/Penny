using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMessageHandler : MonoBehaviour
{
	[SerializeField] private GameObject gameMessageHolder;
	[SerializeField] private TMP_Text gameMessageText;

	private bool newMessageRecieved;
	private float timeMessageWasRecieved;

	private void Start()
	{
		GameManager.Instance.UIManager.RecieveGameMessageHandler(this);

		HideGameMessage();
	}

	public void ShowGameMessage(string _message)
	{		
		newMessageRecieved = true;
		timeMessageWasRecieved = Time.time + 1;

		gameMessageText.text = _message;
		gameMessageHolder.SetActive(true);
		WaitToHideGameMessage();
	}	

	private void Update()
	{
		WaitToHideGameMessage();
	}

	private void WaitToHideGameMessage()
	{		
		if(!newMessageRecieved)
			return;

		if(timeMessageWasRecieved <= Time.time)
		{
			HideGameMessage();
			newMessageRecieved = false;
		}		
	}

	private void HideGameMessage()
	{
		gameMessageHolder.SetActive(false);
	}
}
