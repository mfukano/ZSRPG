﻿using UnityEngine;
using System.Collections;

public class Enemy_AI_Ranged : MonoBehaviour {

	// MyOwner
	public Enemy Owner;

	// Location Vars
	public bool DoISeePlayer;
	public Vector3 LastKnownLocation;
	public Transform TargetLocation;
	public Player TargetPlayer;

	// Visual Variables
	public float fieldOfViewAngle = 110;
	public int fieldOfViewDistance = 100;
	public bool playerInSight;
	public Vector3 personalLastKnownLocation;
	private GameObject player;
	private Animator playerAnim;
	private Vector3 previousSighting;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Use this for initialization
	void Start () {
		Owner = (Enemy)gameObject.GetComponentInParent (typeof(Enemy));
		TargetPlayer = (Player)GameObject.FindObjectOfType (typeof(Player));
	}
	
	// Update is called once per frame
	void Update () {
		// Going to try to make the enemy look at the player
		//DoISeePlayer = true;
		if (playerInSight) 
		{
			TargetLocation = TargetPlayer.transform;
			Owner.transform.rotation =
				Quaternion.LookRotation (Vector3.forward, TargetLocation.position - transform.position);
		}

		// Seeing the player
		if (LastKnownLocation != previousSighting)
			personalLastKnownLocation = LastKnownLocation;

		previousSighting = LastKnownLocation;

		//TODO: Check player health here
	}

	void OnTriggerStay2D(Collider2D other)
	{
		// Skip anything not the player
		if (other.gameObject != player)
						return;
		// Player is hidden by default
		playerInSight = false;

		Vector3 direction = other.transform.position - transform.position;
		// Transform.up is used since the player is looking up to begin with
		float angle = Vector3.Angle (direction, transform.up);
		if (angle < fieldOfViewAngle * 0.5f) 
		{
			// Save current object layer
			int oldLayer = gameObject.layer;

			// Change object layer to a layer it will be alone
			gameObject.layer = LayerMask.NameToLayer("Ghost");
			int layerToIgnore = 1 << gameObject.layer;
			layerToIgnore = ~layerToIgnore;

			RaycastHit2D hit = 
				Physics2D.Raycast(transform.position, direction.normalized, fieldOfViewDistance, layerToIgnore);
			Debug.Log (hit.distance);

			if(hit.collider.gameObject == player)
			{
				playerInSight = true;

				// Set last global sighting is player current position
				LastKnownLocation = player.transform.position;

				Debug.Log("See the player!");
			}
			gameObject.layer = oldLayer;
		}

		// Code here can be used to check animation frames to see if he is sneaking.

		// EXAMPLE CODE:
		// Store the name hashes of the current states.
		/*int playerLayerZeroStateHash = playerAnim.GetCurrentAnimatorStateInfo(0).nameHash;
		int playerLayerOneStateHash = playerAnim.GetCurrentAnimatorStateInfo(1).nameHash;
		
		// If the player is running or is attracting attention...
		if(playerLayerZeroStateHash == hash.locomotionState || playerLayerOneStateHash == hash.shoutState)
		{
			// ... and if the player is within hearing range...
			if(CalculatePathLength(player.transform.position) <= col.radius)
				// ... set the last personal sighting of the player to the player's current position.
				personalLastSighting = player.transform.position;
		}*/
	}
}
