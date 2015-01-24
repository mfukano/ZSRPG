﻿using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	private int levelWidth;
	private int levelHeight;

	public Transform grassTile;
	public Transform lavaTile;

	private Color[] tileColors;

	public Color grassColor;
	public Color lavaColor;

	public Texture2D levelTexture;

	public Entity player;

	// Use this for initialization
	void Start () {
		levelWidth = levelTexture.width;
		levelHeight = levelTexture.height;
		loadLevel ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void loadLevel()
	{
		tileColors = new Color[levelWidth * levelHeight];
		tileColors = levelTexture.GetPixels();

		for (int y = 0; y < levelHeight; y++)
		{
			for (int x = 0; x < levelWidth; x++)
			{
				if (tileColors[x+(y*levelWidth)] == grassColor)
				{
					Instantiate(grassTile, new Vector3(x,y), Quaternion.identity);
				}
				if (tileColors[x+(y*levelWidth)] == lavaColor)
				{
					Instantiate(lavaTile, new Vector3(x,y), Quaternion.identity);
				}
			}
		}
	}
}