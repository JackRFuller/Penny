using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using System;

public class NetworkManager : Photon.MonoBehaviour
{
	public event Action JoinedOrCreatedRooom;
	public event Action<PhotonPlayer> PlayerJoinedRoom;
	public event Action FilledRoom;

	private void Start()
	{
		PhotonNetwork.ConnectUsingSettings("Pre-Alpha");
	}

	public virtual void OnConnectedToMaster()
	{
		Debug.Log("Connected to Master");
	}

	public virtual void JoinOrCreateRoom()
	{
		RoomOptions roomOptions = new RoomOptions();
		roomOptions.MaxPlayers = 2;
		
		PhotonNetwork.JoinOrCreateRoom("newRoom",roomOptions,null);
	}

	public virtual void OnJoinedRoom()
	{		
		JoinedOrCreatedRooom();

		//Check if we're second to join & if so show player two name & begin countdown for match start
		if(PhotonNetwork.playerList.Length > 1)
		{
			PlayerJoinedRoom(PhotonNetwork.playerList[0]);
			FilledRoom();
		}	

		Debug.Log("OnJoinedRoom");		
	}

	public virtual void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
	{
		PlayerJoinedRoom(newPlayer);
		
		if(PhotonNetwork.playerList.Length > 1)
		{
			FilledRoom();
		}
		Debug.Log("OnPhotonPlayerConnected");
	}

	#region MainMenuFunctions

	public void SetPlayerName(string _playerName)
	{
		PhotonNetwork.playerName = _playerName;		
	}

	#endregion
}
