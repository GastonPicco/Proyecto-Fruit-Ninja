using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutable : MonoBehaviour   
{
    [SerializeField] bool cutable;
    [SerializeField] GameObject[] SlicePrefab;
    [SerializeField] GameObject sliceInstanBot, sliceInstanTop;
    [SerializeField] GameObject ParticulasExplocion;

    ParticleSystem juice;
    public int puntos;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 0.45f)
        {
            puntos = 15;
        }
        else if (transform.position.y > -0.2f)
        {
            puntos = 10;
        }
        else if(transform.position.y < -0.2f)
        {
            puntos = 5;
        }
        if(transform.position.y < -3)
        {
            Destroy(gameObject);
        }
        if (GameManager.data.reiniciar)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (cutable)
        {
            sliceInstanBot = Instantiate(SlicePrefab[0], transform.position, gameObject.transform.localRotation);
            sliceInstanTop = Instantiate(SlicePrefab[1], transform.position, gameObject.transform.localRotation);
            juice = sliceInstanTop.GetComponentInChildren<ParticleSystem>();
            sliceInstanTop.GetComponentInChildren<ParticleSystem>().transform.parent = null;
            juice.Play();
            Rigidbody rb0 = sliceInstanBot.GetComponent<Rigidbody>();
            rb0.velocity = this.GetComponent<Rigidbody>().velocity;
            Rigidbody rb1 = sliceInstanTop.GetComponent<Rigidbody>();           
            rb1.velocity = this.GetComponent<Rigidbody>().velocity;
            GameManager.data.puntos = GameManager.data.puntos + puntos;
            Destroy(gameObject);
        }
        if (!cutable)
        {
            Destroy(gameObject);
            GameManager.data.errores += 1;
            Instantiate(ParticulasExplocion, transform.position, Quaternion.identity);
            GameManager.data.error = true;
        }
    }
}
