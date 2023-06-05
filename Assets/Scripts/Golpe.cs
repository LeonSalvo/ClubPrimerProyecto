using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe : MonoBehaviour
{
    [SerializeField] private GameObject jeringa; // Referencia al objeto de la lanza en Unity
    [SerializeField] private float distanciaAtaque = 1f; // Distancia recorrida por el ataque
    [SerializeField] private float duracion = 0.5f;  // Duración del ataque en segundos
    public bool estaAtacando = false; // Variable para controlar el estado del ataque
    private float temporizador = 0f; // Temporizador para controlar la duración del ataque
    private Rigidbody2D rb;
    private GameObject player;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        jeringa.transform.position = transform.position;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !estaAtacando)
        {
            comienzoAtaque();
        }

        if (estaAtacando)
        {

            moverJeringa();
            temporizador += Time.deltaTime;

            if (temporizador >= duracion)
            {
                pararAtaque();
            }
        }
    }

    void comienzoAtaque()
    {
        Movimiento.noGirar = true;
        estaAtacando = true;
        temporizador = 0f;
        jeringa.SetActive(true); // Activa la jeringa visualmente
    }

    void pararAtaque()
    {
        Movimiento.noGirar = false;
        estaAtacando = false;
        jeringa.SetActive(false); // Desactiva la jeringa visualmente
        jeringa.transform.position = transform.position; // Vuelve la jeringa a la posición inicial
        if(Input.GetKey(KeyCode.RightArrow) && !Movimiento.mirandoDer){
            transform.Rotate(0, 180, 0);
            Movimiento.mirandoIzq = false;
            Movimiento.mirandoDer = true;

        }else if(Input.GetKey(KeyCode.LeftArrow) && !Movimiento.mirandoIzq){
            transform.Rotate(0, 180, 0);
            Movimiento.mirandoIzq = true;
            Movimiento.mirandoDer = false;
        }
    }

    void moverJeringa()
    {
        float distancia = distanciaAtaque * Time.deltaTime;
        float velocidad = distancia / duracion;
        jeringa.transform.Translate(Vector2.right * velocidad);

        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemigo"){
            player.SendMessage("RecibirAzucaruro", 20);
            other.GetComponent<Animator>().SetTrigger("Muerto");
        }
    }
}
