using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public float velocidad;

    public float fuerzaSalto;
    public int saltosMaximos;
    public int saltosRestantes;

    public LayerMask capaSuelo;
    

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    private bool mirandoDerecha = true;
    

    private void Awake() 
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMaximos;
    }

    
    void Update()
    {
        Movimiento();
        Salto();
    }

    bool EstaEnElSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, new Vector2(bc.bounds.size.x, bc.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }

    void Salto()
    {
        if(EstaEnElSuelo())
        {
            saltosRestantes = saltosMaximos;
        }
        if(Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            saltosRestantes--;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    void Movimiento()
    {
        float mover = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(mover * velocidad, rb.velocity.y);

        if(mover > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if ( mover < 0 && mirandoDerecha)
        {
            Girar();
        }
    }

    void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.Rotate(0f, 180f, 0f);
    }
}
