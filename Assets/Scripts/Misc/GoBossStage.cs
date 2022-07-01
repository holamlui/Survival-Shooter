using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoBossStage : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			SceneManager.LoadScene (2);
			//Application.LoadLevel (2);
	}
}
}