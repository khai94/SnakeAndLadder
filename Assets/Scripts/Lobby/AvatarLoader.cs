﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarLoader : MonoBehaviour {
	public PlayerSlot slot;
	private Image image;

	// Use this for initialization
	void Start () {
		image = gameObject.GetComponent<Image> ();
		slot.SetAvatar ();
	}

	public void ChangeAvatar(Sprite spr)
	{
		image.sprite = spr;
	}
}
