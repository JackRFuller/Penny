using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class TurnManager : Photon.MonoBehaviour
{
	private static Turn turn;
	public static Turn PlayerTurn {get {return turn;}}
	public enum Turn
	{
		Player,
		Opponent,
	}


	private void Start()
	{
		GameManager.Instance.MatchManager.MatchStarted += DetermineWhichPlayerGoesFirst;
	}

	private void DetermineWhichPlayerGoesFirst()
	{
		//Check if player is host and let them go first
		//In real game we need to generate a random number and assign from there
		turn = PhotonNetwork.isMasterClient? Turn.Player : Turn.Opponent;

		string playerName = PhotonNetwork.playerList[0].IsMasterClient? PhotonNetwork.playerList[0].NickName : PhotonNetwork.playerList[1].NickName;
		GameManager.Instance.UIManager.GameMessage.ShowGameMessage(playerName + " Goes First!");		
	}
}
