using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    private Vector2 dest = Vector2.zero;
    private Rigidbody2D rb2d;
    private float power;
    private int breakPower = 0;
    private bool isRam = false;
    private Wall wall;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //dest = transform.position;
    }

    void Update()
    {
        if(!isRam)
        {
            if (Input.GetKey(KeyCode.W))
                dest = new Vector2(0, 1);
            if (Input.GetKey(KeyCode.S))
                dest = new Vector2(0, -1);
            if (Input.GetKey(KeyCode.D))
                dest = new Vector2(1, 0);
            if (Input.GetKey(KeyCode.A))
                dest = new Vector2(-1, 0);
            Vector2 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
     //ganti
            float angle = Mathf.Atan2(transform.position.y - cursor.y, transform.position.x - cursor.x) * Mathf.Rad2Deg;
            rb2d.velocity = dest*speed;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+180));
        }
        else if (isRam)
        {
            rb2d.velocity = transform.right * power;
            power -= Time.deltaTime * 100;
            if (power < 0)
            {
                isRam = false;
                breakPower = 0;
            }
        }

        if (Input.GetMouseButton(0))
        {        
            power += Time.deltaTime * 10;
            for (int i = 1, k = 10; i <= 2; i++,k+=10)
            {
                if(power < k&& power >= k-10 && power > 0)
                {
                    breakPower = i;
                }
            }
            if (power > 20)
            {
                isRam = true;
            }
            //Debug.Log(power);
        }
        if(Input.GetMouseButtonUp(0))
        {
            isRam = true;
        }

        
 
    }
  
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TembokRidho"))
        {
            dest = Vector2.zero;
            if (breakPower == 2 && isRam)
            {
                wall = FindObjectOfType<Wall>();
                wall.Destroying();
            }
            
        }
    }
}
