using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameFramework.GameStructure.Levels;
using GameFramework.UI.Buttons.Components.AbstractClasses;
using GameFramework.Billing;
using GameFramework.FreePrize.Components;
using GameFramework.GameStructure;



public class enemy : MonoBehaviour {

	//public int[] move_direction = new int[] {0,0};
	public int[] curr_move_direction = new int[] {0,0};
	
	public float speed = 1;
	//public int angle = 0;
	public int k;
	public int test;
	public Vector2 curr_pos = new Vector2(1,1);
	//public GameObject blocker;
	public int no_of_dots = 298;
	public gameController central;
	public GameObject explosion;
	public int test2 = 0;
	
	

	
	void Start () {
		//move_direction = new int[] {0,0};
		central = GameObject.FindWithTag("play").GetComponent("gameController") as gameController;

	}
	
	// Update is called once per frame
	void Update () {
		if(LevelManager.Instance.IsLevelPaused) return;
		
		this.transform.localPosition += new Vector3(0.016f*curr_move_direction[0]*speed,0.016f*curr_move_direction[1]*speed,0);
		k++;
		if(k>9){
			k=0;
			int no_of_directions = 0;
			int[,] directions = new int[,] {{0,0},{0,0},{0,0},{0,0}};
			if(central.map[(int)curr_pos.y,(int)curr_pos.x+1] !=0 && curr_move_direction[0]!=-1)
			{
				directions[no_of_directions,0] = 1;
				directions[no_of_directions,1] = 0;
				no_of_directions++;

			}
			if(central.map[(int)curr_pos.y,(int)curr_pos.x-1] !=0 && curr_move_direction[0]!=+1)
			{
				directions[no_of_directions,0] = -1;
				directions[no_of_directions,1] = 0;
				no_of_directions++;
				
			}
			if(central.map[(int)curr_pos.y-1,(int)curr_pos.x] !=0 && curr_move_direction[1]!=-1)
			{
				directions[no_of_directions,0] = 0;
				directions[no_of_directions,1] = 1;
				no_of_directions++;
				
			}
			if(central.map[(int)curr_pos.y+1,(int)curr_pos.x] !=0 && curr_move_direction[1]!=+1)
			{
				directions[no_of_directions,0] = 0;
				directions[no_of_directions,1] = -1;
				no_of_directions++;
					
			}
			int temp = Random.Range(0,no_of_directions);
			curr_move_direction[0] = directions[temp,0];
			curr_move_direction[1] = directions[temp,1];
			
			//test = central.map[(int)curr_pos.y - move_direction[1],(int)curr_pos.x + move_direction[0]];
			
			if(no_of_directions==0){
				curr_move_direction[0] = -curr_move_direction[0];
				curr_move_direction[1] = -curr_move_direction[1];
			}
			//this.transform.localRotation = Quaternion.Euler(0,0,angle);
			if(curr_pos.y == 12&&curr_pos.x == 14) central.no_of_enemies--;
			curr_pos += new Vector2(curr_move_direction[0],-curr_move_direction[1]);

		}
		//this.transform.localPosition.y+=0.016f*move_direction[1];
		
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
    	test2++;
    	if(collision.gameObject.tag=="Bullet"){
    		int coins_random = Random.Range(1,4);
    		//GameManager.Instance.Player.AddCoins(coins_random);
            GameManager.Instance.Levels.Selected.AddPoints(Random.Range(4,8));
            GameManager.Instance.Levels.Selected.AddCoins(coins_random);
    		Instantiate(explosion,this.transform.position,this.transform.rotation);
    		Destroy(collision.gameObject);
    		Destroy(this.gameObject);
    	}
    }
}
