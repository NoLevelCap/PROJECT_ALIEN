using UnityEngine;
using System.Collections;

public class InteractionPlaneController : MonoBehaviour {

	public GameObject _Enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Q)){
			GameObject newO = GameObject.Instantiate (_Enemy);
			newO.transform.parent = transform;
		}
	}
}
