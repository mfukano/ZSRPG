﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float dmg;
	public float speed;

	void Start () {
	}

	public void ShootGun(string gun) {
		Transform pd3 = transform.Find("projectile_direction3");
		switch (gun) {
		case("Shotgun"):
			Transform pd1 = transform.Find("projectile_direction1");
			Transform pd2 = transform.Find("projectile_direction2");
			Transform pd4 = transform.Find("projectile_direction4");
			Transform pd5 = transform.Find("projectile_direction5");
			GameObject bullet1 = Instantiate(Resources.Load("Prefabs/ShotgunPellet"), pd1.position, pd1.rotation) as GameObject;
			GameObject bullet2 = Instantiate(Resources.Load("Prefabs/ShotgunPellet"), pd2.position, pd2.rotation) as GameObject;
			GameObject bullet3 = Instantiate(Resources.Load("Prefabs/ShotgunPellet"), pd3.position, pd3.rotation) as GameObject;
			GameObject bullet4 = Instantiate(Resources.Load("Prefabs/ShotgunPellet"), pd4.position, pd4.rotation) as GameObject;
			GameObject bullet5 = Instantiate(Resources.Load("Prefabs/ShotgunPellet"), pd5.position, pd5.rotation) as GameObject;
			break;
		case("Laser Pistol"):
			GameObject laser = Instantiate(Resources.Load("Prefabs/Laser"), pd3.position, pd3.rotation) as GameObject;
			break;
		case("Rocket Launcher"):
			GameObject missile = Instantiate(Resources.Load("Prefabs/Missile"), pd3.position, pd3.rotation) as GameObject;
			break;
		case("Pistol"):
			GameObject bullet = Instantiate(Resources.Load("Prefabs/bullet"), pd3.position, pd3.rotation) as GameObject;
			break;
		case("Sniper Rifle"):
			GameObject sniper_bullet = Instantiate(Resources.Load("Prefabs/bullet"), pd3.position, pd3.rotation) as GameObject;
			break;
		case("SMG"):
			GameObject smg_bullet = Instantiate(Resources.Load("Prefabs/bullet"), pd3.position, pd3.rotation) as GameObject;
			break;
		default:
			break;
		}
	}


	public void DoDamage() {
		//deal damage to player
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
