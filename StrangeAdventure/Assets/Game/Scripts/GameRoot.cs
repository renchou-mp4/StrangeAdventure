using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UImanager.Instance.PushUIpanel("UIStart");
	}
}
