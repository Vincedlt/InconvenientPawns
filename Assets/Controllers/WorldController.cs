using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

	public Sprite floorSpirte;


	World world;
	// Use this for initialization
	void Start () {
		// Create a world with Empty tiles
		world = new World ();


		// Create a GameObject for each tile so it shows up visually.
		for (int x = 0; x < world.Width; x++) {
			for (int y = 0; y < world.Height; y++) {
				Tile tile_data = world.GetTileAt (x, y);

				GameObject tile_go = new GameObject ();
				tile_go.name = "Tile_" + x + "_" + y;
				tile_go.transform.position = new Vector3 (tile_data.X, tile_data.Y, 0);

				//Add a sprite renderer, dont set sprite
				// because tiles are empty currently. 
				tile_go.AddComponent<SpriteRenderer> ();

				tile_data.RegisterTileTypeChangedCallback( Foo );
			}
		}
		world.RandomizeTiles ();
	}

	float randomizeTileTimer = 2f;

	// Update is called once per frame
	void Update () {
		randomizeTileTimer -= Time.deltaTime;

		if (randomizeTileTimer < 0) {
			world.RandomizeTiles ();
			randomizeTileTimer = 2f;
		}
	}

	void Foo(Tile tile_data) {
	}

	void OnTileTypeChanged(Tile tile_data, GameObject tile_go) {

		if (tile_data.Type == Tile.TileType.Floor) {
			tile_go.GetComponent<SpriteRenderer> ().sprite = floorSpirte;
		} else if (tile_data.Type == Tile.TileType.Empty) {
			tile_go.GetComponent<SpriteRenderer> ().sprite = null;
		} else {
			Debug.LogError ("OnTileTypeChanged - Unrecognized tile type.");
		}



	}
}
