using UnityEngine;

public class Azucaruro : MonoBehaviour
{
    public int maxAzucaruro = 100;
    public int azucaruroActual;

    public BarraAzucaruro barraAzucaruro;

    // Start is called before the first frame update
    void Start()
    {
        azucaruroActual = 1;
        barraAzucaruro.SetMaxAzucaruro(maxAzucaruro);
        barraAzucaruro.SetAzucaruro(azucaruroActual);
    }

    void RecibirAzucaruro(int azucaruro)
    {
        azucaruroActual += azucaruro;
        barraAzucaruro.SetAzucaruro(azucaruroActual);
    }
}

