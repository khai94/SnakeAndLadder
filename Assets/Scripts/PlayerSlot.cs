using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlot : MonoBehaviour {
	public InputField nameField;
	public Image avatarImage;
	public Toggle botToggle;

	public string name;
	public Sprite avatar;
	public bool isBot;

	void Start()
	{
		nameField = GetComponentInChildren<InputField> ();
		//avatarImage = GetComponentInChildren<Image> ();
		botToggle = GetComponentInChildren<Toggle> ();
	}

	void Update()
	{
		if (!avatar) {
			avatar = avatarImage.sprite;
		}
	}

	public void SetName()
	{
		name = nameField.text;
	}

	public void SetAvatar()
	{
		avatar = avatarImage.sprite;
	}

	public void SetIsBot()
	{
		isBot = botToggle.isOn;
	}
}
