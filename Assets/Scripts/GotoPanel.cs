using UnityEngine;
using System.Collections;

public class GotoPanel : MonoBehaviour {
	
	public GameObject target;
	public GameObject panel;
		
	void Start(){
		
	}
	
	void OnClick(){
		iTween.MoveTo(panel, iTween.Hash("x", 1.5, "time", 0.1, "oncomplete", "MoveIt", "oncompletetarget", gameObject));
		iTween.MoveTo(target, iTween.Hash("x", -1.5, "time", 0.1, "oncomplete", "MoveIt1", "oncompletetarget", gameObject));
	}
	
	void MoveIt(){
		iTween.MoveTo(panel, iTween.Hash("x", 0, "z", 1, "time", 1));
	}
	
	void MoveIt1(){
		iTween.MoveTo(target, iTween.Hash("x", 0, "z", -1, "time", 1));
	}
}
