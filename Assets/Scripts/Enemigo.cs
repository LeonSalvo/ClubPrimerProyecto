using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemigo : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private LayerMask suelo;
    [SerializeField] private float distanciaAgro;
    [SerializeField] private float varX;
    [SerializeField] private float varY;
    [SerializeField] private int vida;
    public bool estaVivo;
    private Rigidbody2D rb;
    private Transform playerTransform;
    private bool puedeSaltar;
    private CircleCollider2D circleCollider; 
    private float distanciaAlJugador;
    private bool playerALaDerecha;
    
    // Start is called before the first frame update
    void Start()
    {   
        estaVivo = true;
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        circleCollider = GetComponent<CircleCollider2D>();
        puedeSaltar = false;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.x > transform.position.x){
            playerALaDerecha = true;
        }else{
            playerALaDerecha = false;
        }
        distanciaAlJugador = Vector2.Distance(transform.position, playerTransform.position);

        if (distanciaAlJugador < distanciaAgro && EstaEnSuelo()){
            puedeSaltar = true;
        }
    }
    private void FixedUpdate() {
        if (puedeSaltar && estaVivo){
            rb.velocity = new Vector2(0,0);
            if (playerALaDerecha){
                rb.AddForce(new Vector2(Mathf.Abs(Mathf.Cos(varX) * 1.5f), Mathf.Abs(Mathf.Sin(varY)*1.7f) * fuerzaSalto) , ForceMode2D.Impulse);
            }else{
                rb.AddForce(new Vector2(-(Mathf.Abs(Mathf.Cos(varX)) * 1.5f), Mathf.Abs(Mathf.Sin(varY)*1.7f) * fuerzaSalto) , ForceMode2D.Impulse);
            }
            
            puedeSaltar = false;
        }else{
            rb.rotation = 0;
            if(EstaEnSuelo()){
                rb.velocity = new Vector2(0,0);
            }
        }
    }
    private bool EstaEnSuelo(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(circleCollider.bounds.center, new Vector2(circleCollider.bounds.size.x, circleCollider.bounds.size.y), 0f, Vector2.down, 0.1f, suelo); 
        return raycastHit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && estaVivo)
        {
            player.SendMessage("RecibirDanio", 20);
        }
    }
    void RecibirDanio(int danio)
    {
        vida -= danio;
        Debug.Log(vida);
        if(vida <= 0){
            estaVivo = false;
        }
    }

}
