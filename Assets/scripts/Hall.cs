using UnityEngine;
using System.Collections;

public class Hall : MonoBehaviour {
	public GameObject[] doors;
	public string roomname;
	public GameObject[] items;
	public float maxX;
	public float minX;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void hideroom(bool hide){
		gameObject.SetActive (!hide);

	}
}
