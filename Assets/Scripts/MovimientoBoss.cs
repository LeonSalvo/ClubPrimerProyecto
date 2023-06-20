using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBoss : MonoBehaviour
{
    [SerializeField] public double vida;
    [SerializeField] private LayerMask suelo;
    [SerializeField] public int daño;
    [SerializeField] public double distanciaDaño;
    [SerializeField] public int dañoHabilidad1;
    [SerializeField] public double distanciaHabilidad1;
    [SerializeField] public int dañoHabilidad2;
    [SerializeField] public double distanciaHabilidad2;
    [SerializeField] public int dañoHabilidad3;
    [SerializeField] public double distanciaHabilidad3;
    [SerializeField] private float velocidad;
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;
    private GameObject player;
    private float distanciaAlJugador;
    private bool puedeSaltar;
    private bool estaActivo;
    private float direccion;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        circleCollider = GetComponent<CircleCollider2D>();
        puedeSaltar = false;
        estaActivo = false;
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
        } 

    }
    public void setActivo(bool booleano){
        estaActivo = booleano;
    }
}
