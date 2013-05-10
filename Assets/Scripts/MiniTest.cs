using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class MiniTest : MonoBehaviour {
	
	public UILabel title1;
	public UILabel title2;
	public UILabel text1;
	public UILabel text2;
	
	private List<UILabel> _title = new List<UILabel>();
	private List<UILabel> _text = new List<UILabel>();
	
	void Start () {
		StartCoroutine("GetUpdate");
	}
	
	IEnumerator GetUpdate() {
		WWW www = new WWW("http://stag-dcsan.dotcloud.com/shop/items/charm");
		float elapsedTime = 0.0f;
		while (!www.isDone) {
			elapsedTime += Time.deltaTime;
			if (elapsedTime >= 10.0f) break;
				yield return null;
		}
		if (!www.isDone || !string.IsNullOrEmpty(www.error)) {
			Debug.LogError(string.Format("Error!\n{0}", www.error));
  			yield break;
		}
		ListAdd();
		string response = www.text;
		IList items = (IList) Json.Deserialize(response);
		for(int i = 1, j = 0; i <= 2; i++, j++){
			IDictionary item = (IDictionary) items[i];
			_title[j].text = item["dname"].ToString();
			_text[j].text = "Description: " + item["description"].ToString() + "\n\nPrice: Php" + item["price"];
		}
	}
	
	void ListAdd(){
		_title.Add(title1);
		_title.Add(title2);
		_text.Add(text1);
		_text.Add(text2);
	}
}
