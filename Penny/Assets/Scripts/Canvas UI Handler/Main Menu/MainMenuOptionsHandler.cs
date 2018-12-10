using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuOptionsHandler : MonoBehaviour
{
	[Header("Player Names")]
	[SerializeField] private GameObject playerOneName;
	[SerializeField] private GameObject playerTwoName;
	[SerializeField] private TMP_Text playerOneNameText;
	[SerializeField] private TMP_Text playerTwoNameText;

	[Header("Set Player Name")]
	[SerializeField] private GameObject playernameInputField;
	[SerializeField] private GameObject joinRoomButton;

	void Start()
	{
		HidePlayerNames();

		GameManager.Instance.NetworkManager.JoinedOrCreatedRooom += HideJoinRoomOptions;
		GameManager.Instance.NetworkManager.JoinedOrCreatedRooom += UpdatePlayerOneName;
		GameManager.Instance.NetworkManager.PlayerJoinedRoom += UpdatePlayerTwoName;		
	}

	private void HidePlayerNames()
	{
		playerOneName.SetActive(false);
		playerTwoName.SetActive(false);
	}

	private void UpdatePlayerOneName()
	{
		playerOneNameText.text = PhotonNetwork.playerName;
		playerOneName.SetActive(true);
	}

	private void UpdatePlayerTwoName(PhotonPlayer _newPlayer)
	{
		playerTwoNameText.text = _newPlayer.NickName;
		playerTwoName.SetActive(true);
	}

	private void HideJoinRoomOptions()
	{
		playernameInputField.SetActive(false);
		joinRoomButton.SetActive(false);
	}
	
}
