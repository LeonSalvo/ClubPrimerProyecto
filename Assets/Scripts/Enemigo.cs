using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemigo : MonoBehaviour
{
    public GameObject player;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(player.transform.position);
        gameObject.transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        if (Vector3.Distance(transform.position, player.transform.position) > 1f) //move if distance from target is greater than 1
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }
}
