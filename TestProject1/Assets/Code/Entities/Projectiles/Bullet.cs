﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Enemy")
		{
			Destroy (gameObject);
		}
	}

}