using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe : MonoBehaviour
{
    [SerializeField] private GameObject jeringa; // Referencia al objeto de la lanza en Unity
    [SerializeField] private float velocidadAtaque = 10f; // Velocidad del ataque
    [SerializeField] private float duracion = 0.5f; // Duración del ataque en segundos
    public bool estaAtacando = false; // Variable para controlar el estado del ataque
    private float temporizador = 0f; // Temporizador para controlar la duración del ataque
    private bool mirandoDerecha;
    void Start(){
        jeringa.transform.position = transform.position;
        mirandoDerecha = true;
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
    }

    void moverJeringa()
    {
        float distancia = velocidadAtaque * Time.deltaTime;
        if(Movimiento.mirandoDer){
            jeringa.transform.Translate(Vector2.right * distancia); // Mueve la jeringa hacia la derecha
        }else{
            jeringa.transform.Translate(Vector2.right * distancia); // Mueve la jeringa hacia la izquierda
        }
        
    }
}
