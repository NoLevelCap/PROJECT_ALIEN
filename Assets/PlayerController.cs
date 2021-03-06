﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject _Sword;
	public Camera _MainCamera;
	public int _Speed;

	private Rect MouseBounds;

	// Use this for initialization
	void Start () {
		MouseBounds = new Rect (0,0, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		RotateToMove ();
		CalculateMovement ();
	}

	private void RotateToMove(){
		Vector3 Mouse = _MainCamera.ScreenToWorldPoint(Input.mousePosition);
		Mouse = new Vector3 (Mouse.x, Mouse.y, transform.position.z);
		MouseBounds.center = new Vector2 (Mouse.x, Mouse.y);
		//Vector3 Direction = new Vector3 (transform.localPosition.x, transform.localPosition.y, 0);
		//Vector3 direction = (Mouse - transform.position).normalized;
		//transform.rotation = Quaternion.FromToRotation(transform.up, Mouse);
		//transform.LookAt (Mouse);
		transform.up =  (Mouse - transform.position).normalized;


	}

	private void CalculateMovement(){
		if(Input.GetKey(KeyCode.A)){
			transform.Translate (_Speed * Time.deltaTime, 0, 0);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Translate(_Speed*Time.deltaTime, 0, 0);
		}
		if(Input.GetKey(KeyCode.W)){
			if (!MouseBounds.Contains (transform.position)) {
				transform.Translate(0, _Speed*Time.deltaTime, 0);
			}
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(0, -_Speed*Time.deltaTime, 0);
		}
	}
}
