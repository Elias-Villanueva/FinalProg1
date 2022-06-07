using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform thePlayer;
    public float rangoAgro;
    public float velocidadMov;
    

    Rigidbody2D rb2d;
    public SpriteRenderer theSR;

    public float moveSpeed;
    private bool movingRight;
    public Transform leftPoint, rightPoint;
    public float moveTime, waitTime;
    private float moveCount, waitCount;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;
        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        movimientoAtaque();
    }

    void movimientoAtaque()
    {
        float distJugador = Vector2.Distance(transform.position, thePlayer.position);

        if (distJugador < rangoAgro)
        {
            PerseguirJugador();
        }
        else
        {
            NoPerseguir();
        }
    }

    private void NoPerseguir()
    {
        if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;

            if(movingRight)
            {
                rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);

                theSR.flipX = true;

                if (transform.position.x > rightPoint.position.x)
                {
                     movingRight = false;
                }
            } else
            {
                rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);

                theSR.flipX = false;

                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }
            if (moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }
            
        }else if (waitCount > 0)
            {
                waitCount -= Time.deltaTime;
                rb2d.velocity = new Vector2(0f, rb2d.velocity.y);

                if (waitCount <= 0)
                {
                    moveCount = Random.Range(moveTime * .75f, waitTime * 1.25f);
                }

            }
    }

    private void PerseguirJugador()
    {
        if (transform.position.x < thePlayer.position.x)
        {
            theSR.flipX = true;
            rb2d.velocity = new Vector2(velocidadMov, 0f);
            
        } else if (transform.position.x > thePlayer.position.x)
        {
            theSR.flipX = false;
            rb2d.velocity = new Vector2 (-velocidadMov, 0f);
        }
    }
}
