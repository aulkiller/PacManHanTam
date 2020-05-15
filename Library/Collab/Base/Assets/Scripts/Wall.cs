using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Player player;
    //private void Update()
    //{
    //    player = FindObjectOfType<Player>();
    //}


    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("momoem");
        
       
        if ( collision.gameObject.CompareTag("Player"))
        {
            player = FindObjectOfType<Player>();
            Debug.Log(player.breakPower);
            Debug.Log(player.isRam);
            if (player.breakPower >=2 && player.isRam == true)
                Destroy(gameObject);

        }
     //   dest = Vector2.zero;


    }
}
