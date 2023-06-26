using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBoss : MonoBehaviour
{
    [SerializeField] public double vida;
    [SerializeField] private LayerMask suelo;
    [SerializeField] public int daño;
    [SerializeField] public int dañoHabilidad1;
    [SerializeField] public double distanciaHabilidad1;
    [SerializeField] public float rangoHabilidad1;
    [SerializeField] public int dañoHabilidad2;
    [SerializeField] public double distanciaHabilidad2;
    [SerializeField] public float rangoHabilidad2;
    [SerializeField] public int dañoHabilidad3;
    [SerializeField] public double distanciaHabilidad3;
    [SerializeField] public float rangoHabilidad3;
    [SerializeField] private float velocidad;
    [SerializeField] LayerMask playerMask;
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;
    private GameObject player;
    private float distanciaAlJugador;
    private bool puedeSaltar;
    private bool estaActivo;
    private float direccion;
    private bool estaAtacando;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        circleCollider = GetComponent<CircleCollider2D>();
        puedeSaltar = false;
        estaActivo = false;
        estaAtacando = false;
    }

    // Update is called once per frame
    void Update()
    {
        distanciaAlJugador = Vector2.Distance(transform.position, player.transform.position);
        if (distanciaAlJugador > distanciaHabilidad3) {
            if (transform.position.x - player.transform.position.x > 0){
                direccion = -1;
            } else {
                direccion = 1;
            }
            rb.velocity = new Vector2(direccion * velocidad, rb.velocity.y);
        }else if (distanciaAlJugador < distanciaHabilidad3 && distanciaAlJugador > distanciaHabilidad2){
            //mentita gira hasta chocar con una pared y cambia de direccion 2 o 3 veces al final rebota hacia sentido contrario

        }else if (distanciaAlJugador < distanciaHabilidad3 && distanciaAlJugador > distanciaHabilidad2){
            
        }else if (distanciaAlJugador < distanciaHabilidad1){
            //ataque en caida
            slam();
        }
    }
    private void slam(){
        Collider2D[] hitEnemigos = Physics2D.OverlapCircleAll(transform.position, circleCollider.radius * 2, playerMask);
        foreach(Collider2D player in hitEnemigos){
            Debug.Log("aia");
        }
    }
    public void setActivo(bool booleano){
        estaActivo = booleano;
    }
}
