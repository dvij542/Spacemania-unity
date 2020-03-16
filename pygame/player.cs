using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameFramework.GameStructure.Levels;
using GameFramework.UI.Buttons.Components.AbstractClasses;
using GameFramework.GameStructure;



public class player : MonoBehaviour {

	// Use this for initialization
	public int[] move_direction = new int[] {0,0};
	public int[] curr_move_direction = new int[] {0,0};
	public bool test2 = false;
	public float speed = 0;
	public int angle = 0;
	public int k;
	public int test;
	public Vector2 curr_pos = new Vector2(1,1);
	public GameObject blocker;
	public int no_of_dots = 298;
	public Text dots_text;
	public gameController central;
	public GameObject explosion;
	public GameObject Bullet;
	public Text bullets;
	public int bullets_left = 6;
	public Image health;
	public GameObject direction_indicator;
	bool temp = true;
	TouchRecorder swipeRecorder = new TouchRecorder();
	
	void Start () {
		move_direction = new int[] {0,0};
    	//LevelManager.Instance.GameOver(true,0);
    	GameManager.Instance.Levels.Selected.Score = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(LevelManager.Instance.IsLevelPaused) return;
		if(Input.GetKeyDown("right")||(swipeRecorder.isNewTouch() && swipeRecorder.getDeterminedShape==8)){
			move_direction = new int[] {1,0};
			//angle = -90;
			direction_indicator.transform.localRotation = Quaternion.Euler(0,0,-90);
		}
		else if(Input.GetKeyDown("left")||(swipeRecorder.isNewTouch() && swipeRecorder.getDeterminedShape==6)){
			move_direction = new int[] {-1,0};
			//angle = 90;
			direction_indicator.transform.localRotation = Quaternion.Euler(0,0,90);

		}
		else if(Input.GetKeyDown("up")||(swipeRecorder.isNewTouch() && swipeRecorder.getDeterminedShape==9)){
			move_direction = new int[] {0,1};
			//angle = 0;
			direction_indicator.transform.localRotation = Quaternion.Euler(0,0,0);

		}
		else if(Input.GetKeyDown("down")||(swipeRecorder.isNewTouch() && swipeRecorder.getDeterminedShape==7)){
			move_direction = new int[] {0,-1};
			//angle = 180;
			direction_indicator.transform.localRotation = Quaternion.Euler(0,0,180);

		}
		if((Input.GetKeyDown("space")||(swipeRecorder.isNewTouch() && swipeRecorder.getDeterminedShape==1))&&bullets_left>0){
			Instantiate(Bullet,transform.position,transform.rotation);
			bullets_left-=1;
			bullets.text = bullets_left.ToString();
		}
		if (Application.platform == RuntimePlatform.Android)
        {
			move_direction = central.move_direction;
			if(central.fired && bullets_left>0){
				Instantiate(Bullet,transform.position,transform.rotation);
				bullets_left-=1;
				bullets.text = bullets_left.ToString();
			}
		}
		this.transform.localPosition += new Vector3(0.016f*curr_move_direction[0]*speed,0.016f*curr_move_direction[1]*speed,0);
		k++;
		if(k>9){
			k=0;
			//test = map[(int)curr_pos.y - move_direction[1],(int)curr_pos.x + move_direction[0]];
			if(central.dots_map[(int)curr_pos.y ,(int)curr_pos.x]==1) {
				central.dots_map[(int)curr_pos.y ,(int)curr_pos.x] = 0;
				no_of_dots--;
				dots_text.text = no_of_dots.ToString();
                GameManager.Instance.Levels.Selected.AddPoints(2);
				
				Instantiate(blocker,this.transform.position+new Vector3(0,0,0.5f),this.transform.rotation);
				if(no_of_dots<=0){
					LevelManager.Instance.GameOver(true);
				}
				
			}
			if(central.map[(int)curr_pos.y - move_direction[1],(int)curr_pos.x + move_direction[0]] !=0) 
			{
				temp = true;
				curr_move_direction = move_direction;
				curr_pos += new Vector2(move_direction[0],-move_direction[1]);
			}
			else if(central.map[(int)curr_pos.y - curr_move_direction[1],(int)curr_pos.x + curr_move_direction[0]] ==0)
			{	
				curr_move_direction = new int[] {0,0};
				temp = false;
			}
			else{
				curr_pos += new Vector2(curr_move_direction[0],-curr_move_direction[1]);	
			}
			if(temp) angle = 90*Mathf.Abs(curr_move_direction[1]) - 90*curr_move_direction[0] - 90*curr_move_direction[1];
			this.transform.localRotation = Quaternion.Euler(0,0,angle);

		}
		//this.transform.localPosition.y+=0.016f*move_direction[1];
		
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
    	test2 = true;
    	if(collision.gameObject.tag=="Enemy"){
    		health.fillAmount -= 0.2f;
    		if(health.fillAmount > 0.1f){
    			//LevelManager.Instance.GameOver(true,0);
    			
    			Destroy(collision.gameObject);
    			Instantiate(explosion,collision.transform.position,collision.transform.rotation);
    		
    		}
    		else {
    			LevelManager.Instance.GameOver(false);
				Destroy(this.gameObject);
    			Instantiate(explosion,this.transform.position,this.transform.rotation);

    		}
    	}
    	if(collision.gameObject.tag=="Bullet_waiver"){
    		Destroy(collision.gameObject);
    		central.time_for_next_bullet_waiver = (int)Time.time + 5;
			central.bullet_waiver_enabled = true;
    		bullets_left += Random.Range(1,4);
    		bullets.text = bullets_left.ToString();	
    	}
    }
}
