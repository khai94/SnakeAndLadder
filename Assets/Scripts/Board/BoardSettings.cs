﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardSettings : MonoBehaviour {
	public List<Tile> tileList;
    static int chanceCount = 0;

	void Awake () {
		tileList = new List<Tile> ();

		GameObject[] tileArray = GameObject.FindGameObjectsWithTag ("Tile");

		foreach (GameObject go in tileArray) {
			tileList.Add (go.GetComponent<Tile> ());
		}

        
	}

	void Start () {
		tileList.Sort ();

        while (chanceCount < 10)
        {
            Tile t = tileList[Random.Range(10, 91)];

            if (t.type == TileType.Normal)
            {
                t.type = TileType.Chance;
                t.tileNumberText.text = "?";
                t.tileNumberText.color = Color.blue;
                t.ResetTileType();
                chanceCount++;
                Debug.Log(t.type.ToString());
            }
        }
    }
}
