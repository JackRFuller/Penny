using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	private GameMessageHandler gameMessageHandler;
	public GameMessageHandler GameMessage {get {return gameMessageHandler;}}

	public void RecieveGameMessageHandler(GameMessageHandler _gameMessageHandler)
	{
		gameMessageHandler = _gameMessageHandler;
	}
	
}
