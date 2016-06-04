using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour {
	public int gradiant;
	public Light light;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float fade(float it){
		light.intensity = light.intensity - it;
		return light.intensity;
	}
}
