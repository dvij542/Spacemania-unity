using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameFramework.GameStructure.Levels;
using GameFramework.UI.Buttons.Components.AbstractClasses;


public class gameController : MonoBehaviour {
	public GameObject enemy;
	public GameObject gate;
	public int no_of_enemies;
	public Text timer;
	public int k = 0;
	public int time_for_next_wave;
	public int time_for_next_bullet_waiver;
	public GameObject bullet_waiver;
	public bool bullet_waiver_enabled;
	public Vector2[] dots_pos = new Vector2[600];
	public Text time_r;
	public int time_remaining;
	public Image img;
	public float time_left;
	public bool game_paused = false,fired = false,double_touch;
	public float first_touch_time;
	public Vector2 startpos,endpos;
	public int[] move_direction = new int[] {0,0};
	public int[,] map = new int[,] {{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0} ,
	{0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0} ,
	{0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0} ,
	{0,1,0,1,1,0,1,0,1,1,1,0,1,0,0,1,0,1,1,1,0,1,0,1,1,0,1,0} ,
	{0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0} ,
	{0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0} ,
	{0,1,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0} ,
	{0,1,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0} ,
	{0,1,1,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,1,1,0} ,
	{0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0} ,
	{0,1,1,1,1,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0} ,
	{0,1,1,1,1,0,1,0,0,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,1,1,1,0} ,
	{0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,0,1,0,0,1,0,0,0,0,0,0} ,
	{0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,0,1,0,0,1,0,0,0,0,0,0} ,
	{0,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,0} ,
	{0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0} ,
	{0,1,1,1,1,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,1,1,0} ,
	{0,1,1,1,1,0,1,0,0,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,1,1,1,0} ,
	{0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0} ,
	{0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0} ,
	{0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0} ,
	{0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0} ,
	{0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0} ,
	{0,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,0} ,
	{0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0} ,
	{0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0} ,
	{0,1,1,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,1,1,0} ,
	{0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0} ,
	{0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0} ,
	{0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0} ,
	{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};

	public int[,] dots_map = new int[,] {{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0} ,
	{0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0} ,
	{0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0} ,
	{0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0} ,
	{0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0} ,
	{0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0} ,
	{0,1,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0} ,
	{0,1,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0} ,
	{0,1,1,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,1,1,0} ,
	{0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0} ,
	{0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0} ,
	{0,0,0,0,0,0,1,0,0,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,0,0,0,0} ,
	{0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,0,1,0,0,1,0,0,0,0,0,0} ,
	{0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0} ,
	{0,0,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0} ,
	{0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0} ,
	{0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0} ,
	{0,0,0,0,0,0,1,0,0,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,0,0,0,0} ,
	{0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0} ,
	{0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0} ,
	{0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0} ,
	{0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0} ,
	{0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0} ,
	{0,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,0} ,
	{0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0} ,
	{0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0} ,
	{0,1,1,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,1,1,0} ,
	{0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0} ,
	{0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0} ,
	{0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0} ,
	{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};
	public int Swipe_threshold = 1;
	// Use this for initialization
	void Start () {
		for(int i=0;i<6;i++){
			Instantiate(enemy,this.transform);
		}
		//int k=0;
		for(int i=0;i<28;i++){
			for(int j=0;j<28;j++){
				if(dots_map[i,j]==1){
					dots_pos[k++] = new Vector2(i,j);
				}
			}
		}
		time_for_next_bullet_waiver = (int)Time.time + 5;
		no_of_enemies = 6;
		time_remaining = (int)Time.time + 100;
		time_for_next_wave = (int)Time.time + 30;
	}
	
	// Update is called once per frame
	void Update () {
		fired = false;
		if (Input.touchCount > 0)
        {
			
			Touch touch = Input.GetTouch(0);

            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    startpos = touch.position;
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    Vector2 endpos = touch.position;
					Vector2 direction = endpos - startpos;
					if(Mathf.Abs(direction.x)>Swipe_threshold && Mathf.Abs(direction.y)<0.1) move_direction = new int[] {0,(int)Mathf.Sign(direction.x)};  
					else if(Mathf.Abs(direction.y)>Swipe_threshold && Mathf.Abs(direction.x)<0.1) move_direction = new int[] {(int)Mathf.Sign(direction.y),0};  
					else {
						if(double_touch&&(Time.time-first_touch_time)<0.5f) 
						{
							double_touch = false;
							fired = true;
						}
						else{
							double_touch = true;
							first_touch_time = Time.time;
						}
					}
					break;
            }
			
		}
		if(no_of_enemies <= 0){
			map[12,14] = 0;
			gate.SetActive(true);
		}
		time_r.text = ((int)(time_remaining-Time.time)).ToString();
		timer.text = ((int)(time_for_next_wave - Time.time)).ToString();
		img.fillAmount = (float)(time_remaining - Time.time)/100;
		if(Time.time>time_remaining){
			LevelManager.Instance.GameOver(false);
		}
		//time_left = (float)(time_for_next_wave - Time.time)/100;
		if(Time.time>time_for_next_wave){
			map[12,14] = 1;
			gate.SetActive(false);
			for(int i=0;i<6;i++){
				Instantiate(enemy,this.transform);
			}
			no_of_enemies = 6;
			time_for_next_wave = (int)Time.time + 30;
		}
		if(Time.time > time_for_next_bullet_waiver&&bullet_waiver_enabled==true){
			bullet_waiver_enabled=false;
			int k = Random.Range(0,290);
			//dots_map[(int)dots_pos[k].x,(int)dots_pos[k].y] = 2;
			GameObject b = Instantiate(bullet_waiver,this.transform);
			b.transform.localPosition = new Vector3(0.158f*(int)dots_pos[k].y+0.429f,2.745f-0.16f*(int)dots_pos[k].x,-1);
		}

	}
	void Pause_game(){
		game_paused = !game_paused;
	}
}
