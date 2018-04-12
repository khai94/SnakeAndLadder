using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarLoader : MonoBehaviour {
	public PlayerSlot slot;

	// Use this for initialization
	void Start () {
		slot.SetAvatar ();
	}
}
