using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Player player;
    private Grid grid;



    private void OnCollisionStay2D(Collision2D collision)
    {
 
        
       
        if ( collision.gameObject.CompareTag("Player"))
        {
            player = FindObjectOfType<Player>();
            Debug.Log(player.breakPower);
            Debug.Log(player.isRam);
            if (player.breakPower >=2 && player.isRam == true)
            {
                //player.isRam = false;
                //player.breakPower = 0;
                //player.power = 0;
                if(gameObject.CompareTag("TembokRidho"))
                {
                Destroy(gameObject);
                grid = FindObjectOfType<Grid>();
                grid.CreateGrid();

                }
                
            }

        }
     //   dest = Vector2.zero;


    }
}
