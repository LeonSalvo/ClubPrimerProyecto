using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private float setSpeedBoost;
    private float speedBoost;
    [SerializeField] float reduceSlideSpeedMultiplier;
    [SerializeField] float endSlide;
    [SerializeField] private LayerMask capaSuelo;
    private BoxCollider2D boxCollider;
    private float direccion;
    public enum State
    {
        Normal,
        Sliding
    }
    private State state;
    private Rigidbody2D rb2D;

    public static bool mirandoIzq = false;
    public static bool mirandoDer = true;
    public static bool noGirar = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        state = State.Normal;
        speedBoost = setSpeedBoost;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Normal:
                {
                    direccion = Input.GetAxis("Horizontal");
                    rb2D.velocity = new Vector2(direccion * velocidad, rb2D.velocity.y);
                    if (Input.GetKeyDown(KeyCode.UpArrow) && EstaEnSuelo())
                    {
                        rb2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
                    }
                    if (!noGirar)
                    {
                        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && !mirandoIzq)
                        {
                            gameObject.transform.Rotate(0, -180, 0);
                            mirandoIzq = true;
                            mirandoDer = false;
                        }
                        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && !mirandoDer)
                        {
                            gameObject.transform.Rotate(0, 180, 0);
                            mirandoIzq = false;
                            mirandoDer = true;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Z) && EstaEnSuelo())
                    {
                        speedBoost = setSpeedBoost;
                        // Cambio al sliding sprite
                        state = State.Sliding;
                    }
                    break;
                }
            case State.Sliding:
                {
                    if(mirandoIzq){
                        rb2D.velocity = new Vector3(-1f,rb2D.velocity.y,0f) * speedBoost;
                    }
                    else{
                        rb2D.velocity = new Vector3(1f,rb2D.velocity.y,0f) * speedBoost;
                    }
                    speedBoost -= reduceSlideSpeedMultiplier * Time.deltaTime;
                    if (speedBoost < endSlide)
                    {
                        state = State.Normal;
                        // Cambio de sprite al por defecto
                    }
                    break;
                }
        }


    }

    private bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }

    public void OnCollisionEnter2D(Collision2D other){
        if((other.gameObject.tag == "Mapa") && (state.Equals(State.Sliding))){
            state = State.Normal;
            rb2D.velocity = new Vector2(direccion * velocidad, rb2D.velocity.y);
        }
        else if(other.gameObject.tag == "Enemigo" && (state.Equals(State.Sliding))){
            Debug.Log("No colisiono con enemigos");
            other.collider.isTrigger = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Enemigo" && state.Equals(State.Sliding)){
            other.isTrigger = false;
            Debug.Log("Ya colisiono con enemigos");
        }
    }

    public State getCurrentState(){
        return this.state;
    }
}

