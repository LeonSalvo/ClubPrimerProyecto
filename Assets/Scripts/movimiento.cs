using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private LayerMask capaSuelo;
    private BoxCollider2D boxCollider;

    private float direccion;    
    
    private float horizontal;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); 
        boxCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        direccion = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(direccion * velocidad, rb2D.velocity.y);
        if (Input.GetKeyDown(KeyCode.UpArrow) && EstaEnSuelo()){ 
            rb2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    private bool EstaEnSuelo(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo); 
        return raycastHit.collider != null;
    }
}

