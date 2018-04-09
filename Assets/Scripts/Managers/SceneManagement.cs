using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

	public void ChangeScene(int i){
		SceneManager.LoadScene (i);
	}
}
