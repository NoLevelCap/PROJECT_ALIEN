using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject target;
	public float movespeed = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TargetToo (target);
	}

	void TargetToo(GameObject Target){
		transform.up = (Target.transform.position - transform.position).normalized;
		transform.position += Time.deltaTime * movespeed * transform.up;
	} 

	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log ("Collided");
		if(col.gameObject.tag == "Weapon")
		{
			
			Destroy(col.gameObject);
		}
	}
}
