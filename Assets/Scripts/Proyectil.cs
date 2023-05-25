using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] private float angulo;
    [SerializeField] private float velocidadInicial;
    [SerializeField] private float gravedad;
    private float velX, velY;

    // Start is called before the first frame update
    void Start()
    {
        velX = Mathf.Cos(angulo) * velocidadInicial;
        velY = Mathf.Sin(angulo) * velocidadInicial;  
    }

    // Update is called once per frame
    void Update()
    {
        velY -= gravedad * Time.deltaTime; // Aplica la gravedad al proyectil

        Vector2 newPos = transform.position;
        newPos.x += velX * Time.deltaTime;
        newPos.y += velY * Time.deltaTime;

        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag != "Player"){
            Destroy(gameObject);
        }
    }
}
