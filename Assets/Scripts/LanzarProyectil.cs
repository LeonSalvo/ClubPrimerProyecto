using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarProyectil : MonoBehaviour
{
    [SerializeField] private GameObject proyectilPrefab;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)){
            GameObject proyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.identity);
        }
    }
}
