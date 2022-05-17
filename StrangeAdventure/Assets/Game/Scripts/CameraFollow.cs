using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Transform player;
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	

	void Update () {
		float x = Mathf.Lerp(transform.position.x, player.position.x,Time.deltaTime*4f);
		x = Mathf.Clamp(x, 400f, 1580f);//限制X的范围
		transform.position = new Vector3(x, transform.position.y, -10f);
	}
}
