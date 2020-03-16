using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
	public int frames_bet_2_explosions;
	public GameObject[] explosion_animation_frames;
	public int j =0,frame=1;
	// Use this for initialization
	void Start () {
		explosion_animation_frames[0].SetActive(true);
		
		for(int i=1;i<9;i++){
			explosion_animation_frames[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		j++;
		if(j>=frames_bet_2_explosions){
			j=0;
			explosion_animation_frames[frame-1].SetActive(false);
			explosion_animation_frames[frame++].SetActive(true);
			if(frame>8) Destroy(this.gameObject);
		}
	}
}
