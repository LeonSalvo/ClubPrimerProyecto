using UnityEngine;

public class Vida : MonoBehaviour
{
    public int maxVida = 100;
    public int vidaActual;
    public Movimiento playerMovement;

    public BarraVida barraVida;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = 1;
        barraVida.SetMaxVida(maxVida);
        barraVida.SetVida(vidaActual);
        playerMovement = GetComponent<Movimiento>();
    }

    void RecibirDanio(int danio)
    {
        if(playerMovement.getCurrentState().Equals(Movimiento.State.Normal)){
            vidaActual += danio;
            barraVida.SetVida(vidaActual);
        }
    }
}
