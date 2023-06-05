using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int maxVida = 100;
    public int vidaActual;

    public BarraVida barraVida;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = 1;
        barraVida.SetMaxVida(maxVida);
        barraVida.SetVida(vidaActual);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RecibirDanio(int daño)
    {
        vidaActual += daño;
        barraVida.SetVida(vidaActual);
    }
}
