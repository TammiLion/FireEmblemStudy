using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

	public GameObject grassTile;
	public GameObject castleTile;
	public GameObject grassMountainsTile;
	public GameObject steepMountainsTile;
	public GameObject treesTile;
	public GameObject forestTile;
	public GameObject[,] map;

	public GameObject lynCharacter;

	private float width;
	private float height;


	// Use this for initialization
	void Start () {
		width = grassTile.renderer.bounds.size.x;
		height = grassTile.renderer.bounds.size.y;
		map = new GameObject[10,10];
		createMap ();
		putCharactersOnMap ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void createMap() {
		for (int i = 0; i<map.GetLength(0); i++) {
			for (int j = 0; j<map.GetLength(1); j++) {
				GameObject tile = (GameObject) Instantiate(chooseTile(), new Vector3(i*width,j*height,1), new Quaternion(0,0,0,0));
				map[i,j] = tile;
			}	
		}
	}

	private void putCharactersOnMap() {
		float i = Random.Range (0, (map.GetLength (0)));
		float j = Random.Range (0, (map.GetLength (1)));
		//float i = 0;
		//float j = 0;
		float x = i * width;
		float y = j * height;
		Debug.Log ("i: " + i + ", j:" + j + ", width: " + width + ", height: " + height);
		Vector3 position = new Vector3 (x, y, 1);
		Instantiate (lynCharacter, position, new Quaternion(0,0,0,0));
	}

	private GameObject chooseTile() {
		int i = Random.Range(0,6);
		switch (i) {
		case 0:
			return grassTile;
		case 1:
			return castleTile;
		case 2:
			return grassMountainsTile;
		case 3:
			return steepMountainsTile;
		case 4:
			return treesTile;
		case 5:
			return forestTile;
		default:
			return grassTile;
		}
	}
}
