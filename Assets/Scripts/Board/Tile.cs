using UnityEngine;
using System.Collections;

enum TileType {
	Normal,
	Snake,
	Ladder
};

public class Tile : MonoBehaviour {
	public TextMesh tileNumberText;

	private TileType type;
	public int tileNum;
	public int x, y;
	private bool isConnected = false;	// is the tile already connected to another Tile?
	private Tile connectedTile;			// store info of the connected Tile

	// Use this for initialization
	void Start () {
		x = (int)transform.position.x + 10;
		y = (int)transform.position.y * 10;
		tileNum = (x + y) / 10;

		tileNumberText.text = tileNum.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
