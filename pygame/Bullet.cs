using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public Rigidbody2D r;
	public float speed;
	public gameController game;
	public GameObject explosion;
	public int x;
	public int y;
	// Use this for initialization
	void Start () {
		this.transform.parent = GameObject.FindWithTag("play").transform;
		r.velocity = speed * this.transform.up;
		game = GameObject.FindWithTag("play").GetComponent("gameController") as gameController;
	}
	
	// Update is called once per frame
	void Update () {
		x = (int)((this.transform.localPosition.y-2.41f)/(-0.16f));
		y = (int)((this.transform.localPosition.x+2.16f)/(0.16f));
		if(game.map[(int)((this.transform.localPosition.y-2.41f)/(-0.16f)),(int)((this.transform.localPosition.x+2.16f)/(0.16f))]==0){
			Instantiate(explosion,this.transform.position,this.transform.rotation);
			Destroy(this.gameObject);
		}
	}
}
