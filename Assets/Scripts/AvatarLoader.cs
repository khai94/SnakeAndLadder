﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarLoader : MonoBehaviour {
	public PlayerSlot slot;
	public List<Sprite> spriteList;
	private int count;
	private Image image;

	// Use this for initialization
	void Start () {
		image = gameObject.GetComponent<Image> ();
		count = 0;
		slot.SetAvatar ();
	}

	public void ChangeAvatar()
	{
		if (count < spriteList.Count-1)
			count++;
		else
			count = 0;
		
		image.sprite = spriteList [count];
	}
}
