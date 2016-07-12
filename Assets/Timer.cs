using UnityEngine;
using System.Collections;

public class Timer {
	private float StartTime;
	private float Duration;

	public Timer(float Duration){
		this.Duration = Duration;
		StartTimer ();
	}

	public void StartTimer(){
		StartTime = Time.time;
	}

	public float CheckTime(){
		return Time.time - StartTime;
	}

	public bool IsPastTime(){
		return (CheckTime () >= Duration);
	}
}
