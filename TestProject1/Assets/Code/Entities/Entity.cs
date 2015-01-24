﻿using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Mathf.Round (rigidbody2D.position.x),
		                                 Mathf.Round (rigidbody2D.position.y));
	
	}
}