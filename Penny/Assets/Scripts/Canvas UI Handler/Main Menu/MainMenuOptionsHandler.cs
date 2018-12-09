using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuOptionsHandler : MonoBehaviour
{
	[SerializeField] private GameObject playernameInputField;
	[SerializeField] private GameObject joinRoomButton;

	void Start()
	{
		GameManager.Instance.NetworkManager.JoinedOrCreatedRooom += HideJoinRoomOptions;
	}

	private void HideJoinRoomOptions()
	{
		playernameInputField.SetActive(false);
		joinRoomButton.SetActive(false);
	}
	
}
