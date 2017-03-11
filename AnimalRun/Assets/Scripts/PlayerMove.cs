using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	private enum playerState{
		onEvent,
		inAir,
		idle,
		turn
	};
	Vector3 x = new Vector3 (1, 0, 0);//nice to make them const
	Vector3 rx = new Vector3 (-1, 0, 0);
	Vector3 z = new Vector3 (0, 0, 1);
	Vector3 rz = new Vector3 (0, 0, -1);
	private Vector3 incAxis(Vector3 a){//next axis clockwise
		if(a == x)
			return rz;
		if (a == rz)
			return rx;
		if(a == rx)
			return z;
		if(a == z)
			return x;
		print ("warning: strange axis in PlayerMove.incAxis");
		return a;
	}

	private Vector3 decAxis(Vector3 a){//next axis counterclockwise
		if(a == rz)
			return x;
		if(a == rx)
			return rz;
		if(a == z)
			return rx;
		if(a == x)
			return z;
		print ("warning: strange axis in PlayerMove.decAxis");
		return a;
	}

	private float turningSpeed = 0.2f,runningSpeed = 0.2f;
	private playerState state;
	public Vector3 mainAxis;
	Vector3 delta;//current vector of movement

	private int lineNumber;
	private float[] spawnLines;

	private void rotateRight(){//90 degree rotation
		mainAxis=incAxis(mainAxis);
		updateDelta ();
	}
	private void rotateLeft(){//90 degree rotation
		mainAxis=decAxis(mainAxis);
		updateDelta ();
	}

	private void updateDelta(){
		delta = mainAxis * runningSpeed;
	}

	private void turnRight(){
		if (lineNumber < spawnLines.Length - 1) {
			delta += incAxis (mainAxis) * turningSpeed;
			state = playerState.turn;
			lineNumber++;
		} else {
			//TODO
		}
	}

	private void turnLeft(){
		if (lineNumber > 0) {
			delta += decAxis (mainAxis) * turningSpeed;
			state = playerState.turn;
			lineNumber--;
		} else {
			//TODO
		}
	}

	void Start () {
		state = playerState.idle;
		mainAxis = new Vector3(1,0,0);
		delta.x = 0;delta.y = 0;delta.z = 0;
		lineNumber = 1;
		//TODO spawnLines = (float[])gameObject.FindObjectOfType (typeof(float[]));
		spawnLines = new float[]{0.5f,1f,2f,3f};
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (delta);
		switch (state) {
		case playerState.idle:
			if (Input.GetKey (KeyCode.UpArrow))//TMP 
				updateDelta ();
			if (Input.GetKey (KeyCode.RightArrow))
				turnRight ();
			if (Input.GetKey (KeyCode.LeftArrow))
				turnLeft ();
			break;
		}
	}

}