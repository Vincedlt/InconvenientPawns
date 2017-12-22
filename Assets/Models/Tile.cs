﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile {

	public enum TileType { Empty, Floor };

	TileType type = TileType.Empty;

	Action<Tile> cbTileTypeChanged;


	public TileType Type {
		get {
			return type;
		}
		set {
			type = value;
			// Call the callback and let things know we've changed. 

			if(cbTileTypeChanged != null)
			cbTileTypeChanged(this);
		}
	}

	LooseObject looseObject;
	InstalledObject installedObject;

	World world;
	int x;

	public int X {
		get {
			return x;
		}
	}

	int y;
	public int Y {
		get {
			return y;
		}
	}

 

	public Tile( World world, int x, int y ) {
		this.world = world;
		this.x = x;
		this.y = y;
	}

	public void RegisterTileTypeChangedCallback(Action<Tile> callback) {
		cbTileTypeChanged += callback;
	}
	public void UnegisterTileTypeChangedCallback(Action<Tile> callback) {
		cbTileTypeChanged += callback;
	}
}
