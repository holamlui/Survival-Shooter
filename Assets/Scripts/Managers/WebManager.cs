using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WebManager : MonoBehaviour {

	public string url= "http://www2.comp.polyu.edu.hk/~13068504d/gameprog/text.txt";
	public string postUrl= "http://www2.comp.polyu.edu.hk/~13068504d/gameprog/post.php";
	private string text;

	public void popUpScorePanel(){
		//Debug.Log ("iamhere");
		GameObject.Find("ScorePanel").transform.position = new Vector3(797.5f,710.0f,0f);
		//Debug.Log (GameObject.Find ("ScorePanel").transform.position);
		StartCoroutine(getScore());
	}

	IEnumerator getScore() {
		WWW www = new WWW(url);
		yield return www;
		text = www.text;
		string[] splitString = text.Split(';');
		GameObject.Find("Rank1").GetComponent<Text>().text = splitString[0];
	}

	public void submit(){
		StartCoroutine(postScore());
	}

	IEnumerator postScore(){
		ScoreManager scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); 
		int score = scoreManager.GetScore ();
		WWW www = new WWW(url);
		yield return www;
		string text = www.text;
		text = text + score.ToString ();
		WWWForm form = new WWWForm();
		form.AddField("text",text);
		// Upload to a cgi script
		WWW w = new WWW(postUrl, form);
		yield return w;
		if (!string.IsNullOrEmpty(w.error)) {
			print(w.error);
		}
		else {
			print("Finished submission");
		}
	}
	// Use this for initialization

}
