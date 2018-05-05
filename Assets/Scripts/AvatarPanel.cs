using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarPanel : MonoBehaviour {
	public GameObject playerAvatar;
	public List<GameObject> avatarList = new List<GameObject> ();
	public List<Button> playerCreatorButtonList;

	// Use this for initialization
	void Start () {
		GameObject[] array = GameObject.FindGameObjectsWithTag ("Avatar");

		foreach (GameObject go in array) {
			avatarList.Add (go);
		}

		CheckSpriteAvailability ();
	}

	public void LoadPlayerCreator(GameObject avatar)
	{
		playerAvatar = avatar;
	}

	public void ChangeAvatarSprite(Image image)
	{
		Button button = playerAvatar.GetComponentInChildren<Button> ();
		button.image.sprite = image.sprite;
		UnloadAvatarPanel ();
	}

	public void CheckSpriteAvailability()
	{
		Button button;
		for (int i = 0; i < avatarList.Count; i++) {
			button = avatarList [i].GetComponent<Button> ();

			for (int j = 0; j < 6; j++)
			{
				if (playerCreatorButtonList [j].transform.parent.gameObject.activeSelf) {
					if (button.image.sprite == playerCreatorButtonList [j].image.sprite)
						button.interactable = false;
				}
			}
		}
			
	}

	public void ToggleAvatarButton(bool isAble)
	{
		foreach (Button button in playerCreatorButtonList) {
			button.interactable = isAble;
		}
	}

	void UnloadAvatarPanel()
	{
		RectTransform panelTransform = gameObject.GetComponent<RectTransform> ();
		panelTransform.localScale = new Vector3 (1.5f, 0.0f, 1.0f);
		ToggleAvatarButton (true);
	}
}
