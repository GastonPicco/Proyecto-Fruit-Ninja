using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody rB;
    [SerializeField] float force;
    [SerializeField] float aperture;
    void Start()
    {      
        float randomfloat = Random.Range(-aperture, aperture);
        rB = GetComponent<Rigidbody>();
        rB.AddForce(Vector3.up*50*force + Vector3.right*20*randomfloat);
        rB.AddTorque(Vector3.up*1.3f);
        Debug.Log("La cantidad de || Bombas: " + GameManager.data.bombas + " || Frutas: " + GameManager.data.frutas);
    }

    // Update is called once per frame
    void Update()
    {
        if(rB.velocity.y < 0)
        {
            gameObject.layer = 8;
        }
    }
}
