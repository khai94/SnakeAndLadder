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

	public AvatarPanel avatarPanel;

	void Start()
	{
		nameField = GetComponentInChildren<InputField> ();
		//avatarImage = GetComponentInChildren<Image> ();
		botToggle = GetComponentInChildren<Toggle> ();
		avatarPanel = GameObject.Find ("Avatar Panel").GetComponent<AvatarPanel> ();
		SetAll ();
	}

	void Update()
	{
		if (!avatar) {
			avatar = avatarImage.sprite;
		}

		if (avatar != avatarImage.sprite) {
			SetAvatar ();
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

	public void LoadAvatarPanel()
	{
		RectTransform panelTransform = avatarPanel.gameObject.GetComponent<RectTransform> ();
		panelTransform.localScale = new Vector3 (1.5f, 1.5f, 1.0f);
		avatarPanel.LoadPlayerCreator (gameObject);
		avatarPanel.ToggleAvatarButton (false);
	}

	public void SetIsBot()
	{
		isBot = botToggle.isOn;
	}

	private void SetAll()
	{
		SetName ();
		SetAvatar ();
		SetIsBot ();
	}

	public void CheckDuplicate()
	{

	}
}
