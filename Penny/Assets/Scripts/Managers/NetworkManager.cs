using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using System;

public class NetworkManager : Photon.MonoBehaviour
{
	public event Action JoinedOrCreatedRooom;

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
		roomOptions.maxPlayers = 2;
		
		PhotonNetwork.JoinOrCreateRoom("newRoom",roomOptions,null);
	}

	public virtual void OnJoinedRoom()
	{
		Debug.Log("Joined Room");
		JoinedOrCreatedRooom();
	}

	public virtual void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
	{

	}

	#region MainMenuFunctions

	public void SetPlayerName(string _playerName)
	{
		PhotonNetwork.playerName = _playerName;		
	}

	#endregion
}
