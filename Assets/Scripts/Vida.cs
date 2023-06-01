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

    void RecibirDanio(int danio)
    {
        vidaActual += danio;
        barraVida.SetVida(vidaActual);
    }
}
