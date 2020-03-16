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

	public int[] curr_move_direction = new int[] {0,0};
	
	public float speed = 1;
	public int k;
	public int test;
	public Vector2 curr_pos = new Vector2(1,1);
	public int no_of_dots = 298;
	public gameController central;
	public GameObject explosion;
	public int test2 = 0;
	
	void Start () {
		central = GameObject.FindWithTag("play").GetComponent("gameController") as gameController;

	}
	
	// Update is called once per frame
	void Update () {
		if(LevelManager.Instance.IsLevelPaused) return;
		
		this.transform.localPosition += new Vector3(0.016f*curr_move_direction[0]*speed,0.016f*curr_move_direction[1]*speed,0);
		k++;
		if(k>9){
			k=0;
			int no_of_directions = 0; //Possible directions the enemy can go from a particular position
			int[,] directions = new int[,] {{0,0},{0,0},{0,0},{0,0}}; //All possible directions
			//Find all the directions that the enemy can go, lso eliminate the direcction opposite to the current one as the enemy cant move backward to its current direction unless it is compelled to do so
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
			int temp = Random.Range(0,no_of_directions); //Randomly select a direction from all the possible directions
			curr_move_direction[0] = directions[temp,0];
			curr_move_direction[1] = directions[temp,1];
			
			if(no_of_directions==0){//This means that enemy has to move backward from here 
				curr_move_direction[0] = -curr_move_direction[0];
				curr_move_direction[1] = -curr_move_direction[1];
			}
			if(curr_pos.y == 12&&curr_pos.x == 14) central.no_of_enemies--;  //The trapped enemy moved out
			curr_pos += new Vector2(curr_move_direction[0],-curr_move_direction[1]); //Move the enemy after each update

		}
		
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
    	test2++;
    	if(collision.gameObject.tag=="Bullet"){
    		int coins_random = Random.Range(1,4);
    		GameManager.Instance.Levels.Selected.AddPoints(Random.Range(4,8));
            GameManager.Instance.Levels.Selected.AddCoins(coins_random); //Add coins for each bullet hitting the enemy
    		Instantiate(explosion,this.transform.position,this.transform.rotation);  //Explosion instantiation
    		Destroy(collision.gameObject);//Destroy both the bullets and the enemy
    		Destroy(this.gameObject);
    	}
    }
}
