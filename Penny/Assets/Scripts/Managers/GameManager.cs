using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	public static GameManager Instance { get {return instance;}	}

	private NetworkManager networkManager;
	private MatchManager matchManager;
	private TurnManager turnManager;
	private UIManager uIManager;

	public NetworkManager NetworkManager {get {return networkManager;}}
	public MatchManager MatchManager { get { return matchManager;}}
	public TurnManager TurnManager { get { return turnManager;}}
	public UIManager UIManager {get {return uIManager;}}

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this);
		}

		networkManager = GetComponent<NetworkManager>();
		matchManager = GetComponent<MatchManager>();
		turnManager = GetComponent<TurnManager>();
		uIManager = GetComponent<UIManager>();
	}	
}
