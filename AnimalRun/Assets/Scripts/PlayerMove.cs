using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	enum playerState{
		onEvent,
		up,
		down,
		idle,
		right,
		left
	};

	private GameObject player;
	private float jumpSpeed=0.5f, rotationSpeed=0.2f,runningSpeed=0.2f;
	private playerState state;
	// Use this for initialization
	void Start () {
		player = gameObject;
		state = playerState.idle;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow))
			state = playerState.right;
		if (Input.GetKey (KeyCode.LeftArrow))
			state = playerState.left;
		if (Input.GetKey (KeyCode.DownArrow))
			state = playerState.idle;
		transform.Translate (-runningSpeed,0,0);
		switch (state) {
		case playerState.idle:
			if (Input.GetKey (KeyCode.RightArrow))
				state = playerState.right;
			if (Input.GetKey (KeyCode.LeftArrow))
				state = playerState.left;
			break;
		case playerState.right:
			transform.Translate (0, 0, rotationSpeed, player.transform);
			break;
		case playerState.left:
			transform.Translate (0, 0, -rotationSpeed, player.transform);
			break;
		}
	}
	void OnCollisionEnter(Collision col){
		print ("hui");
		state = playerState.idle;	
	}
	void OnCollisionStay(Collision col){
		print ("hui");
		state = playerState.idle;	
	} 
	void OnTriggerEnter(Collider col){
		print ("hui");
		state = playerState.idle;
	}

}