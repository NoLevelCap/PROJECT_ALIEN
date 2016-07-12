using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject target;
	public float movespeed = 3;
	private Rigidbody2D rigidbody;

	public int MaxHealth = 100;
	public int CurrentHealth;

	private bool KnockBack;
	private Timer timer;
	private Vector3 KTarget, KStart;


	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;
		rigidbody = GetComponent<Rigidbody2D> ();
		target = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (KnockBack) {
			transform.up = (target.transform.position - transform.position).normalized;
			transform.position = Vector3.Slerp (KStart, KTarget, timer.CheckTime());
			if(timer.IsPastTime()){
				KnockBack = false;
			}
		} 
		TargetToo ();
		DeathCheck ();
	}

	void DeathCheck(){
		if(CurrentHealth <= 0){
			Destroy (gameObject);
		}
	}

	void TargetToo(){
		transform.up = (target.transform.position - transform.position).normalized;
		transform.position += Time.deltaTime * movespeed * transform.up;
	} 

	void OnCollisionEnter2D (Collision2D col)
	{
		//Debug.Log ("Collided: "+col.gameObject.tag);
		if(col.gameObject.tag == "Weapon")
		{
			hit (col.gameObject.GetComponent<WeaponController>());
		}
	}

	void hit(WeaponController weapon){
		CurrentHealth -= 20;
		//rigidbody.AddForce(-1f*(new Vector2(transform.up.x, transform.up.y)), ForceMode2D.Impulse);
		//rigidbody.AddForce(-1f*(new Vector2(2, 0)), ForceMode2D.Impulse);
		KnockBack = true;
		timer = new Timer (0.2f);
		KTarget = transform.position - transform.up;
		KStart = transform.position;
		DeathCheck ();
	}



}
