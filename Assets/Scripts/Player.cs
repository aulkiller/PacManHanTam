using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    private Vector2 dest = Vector2.zero;
    private Rigidbody2D rb2d;
    public float power;
    public int breakPower = 0;
    public bool isRam = false,play;
    public Vector3 startLocation;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float g = 1;
    private GameStatus gameStatus;
    // private Wall wall;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        startLocation = gameObject.transform.position;
        gameStatus = FindObjectOfType<GameStatus>();
        //dest = transform.position;
        //spriteRenderer.color = Color.white;
    }

    void FixedUpdate()
    {
            animator.SetBool("isPlay", play);
        if (play)
        {
            if (!isRam)
            {
                if (Input.GetKey(KeyCode.W))
                    dest = new Vector2(-1, 0);
                if (Input.GetKey(KeyCode.S))
                    dest = new Vector2(1, 0);
                if (Input.GetKey(KeyCode.D))
                    dest = new Vector2(0, 1);
                if (Input.GetKey(KeyCode.A))
                    dest = new Vector2(0, -1);
                Vector2 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //ganti
                float angle = Mathf.Atan2(transform.position.y - cursor.y, transform.position.x - cursor.x) * Mathf.Rad2Deg;
                rb2d.velocity = dest * speed;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));

                if (Input.GetMouseButton(0))
                {
                    animator.SetBool("isHold", true);

                    power += Time.deltaTime * 10;
                    g -= power / 1000;

                    spriteRenderer.color = new Color(spriteRenderer.color.r, g, spriteRenderer.color.b);
                    //for (int i = 1, k = 10; i <= 2; i++, k += 10)
                    //{
                    //    if (power < k && power >= k - 10 && power > 0)
                    //    {
                    //        //power = 0;
                    //        g = 1;
                    //        breakPower = i;
                    //    }
                    //    if (power >= 20)
                    //    {
                    //        // breakPower = 2;
                    //        g = 1;
                    //        isRam = true;
                    //        animator.SetBool("isHold", false);
                    //    }
                    //}
                    if (power < 20 && power >= 10)
                    {
                        //g = 1;
                        breakPower = 1;
                    }
                    if (power >= 20)
                    {
                        Debug.Log(g);
                        breakPower = 2;
                        g = 1;
                        isRam = true;
                        animator.SetBool("isHold", false);
                    }
                }
                //Debug.Log(power);
                if (Input.GetMouseButtonUp(0))
                {

                    g = 1;
                    spriteRenderer.color = new Color(spriteRenderer.color.r, g, spriteRenderer.color.b);

                    isRam = true;
                    animator.SetBool("isHold", false);
                }
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
            if (Input.GetKey(KeyCode.Escape))
            {
                gameStatus.Pause();
            }
        }
        else if (!play)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, 1, spriteRenderer.color.b);
        }
    }

    public void ResetLocation()
    {
        rb2d.velocity = Vector2.zero;
        dest = Vector2.zero;
        gameObject.transform.position = startLocation;
    }


}
