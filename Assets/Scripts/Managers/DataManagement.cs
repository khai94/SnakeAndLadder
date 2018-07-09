using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Player
{
	public string name;
	public Sprite avatar;
	public bool isBot;
	public bool isActive;
}

public class DataManagement : MonoBehaviour {
	public List<Player> slotList;
	public PlayerCount playerCount;
	public static DataManagement instance;

	// Use this for initialization
	void Start () {

        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
	}

	public void SetPlayerSlot()
	{
		slotList.Clear ();

		foreach (PlayerSlot player in playerCount.playerArray) {
			Player nPlayer;
			nPlayer.name = player.username;
			nPlayer.avatar = player.avatar;
			nPlayer.isBot = player.isBot;
			nPlayer.isActive = player.gameObject.activeSelf;

			slotList.Add (nPlayer);
		}

		//slotList.ForEach (DisplayList);
	}

	private void DisplayList(Player player)
	{
		Debug.Log (player.name + ", " + player.isBot.ToString());
	}
}
