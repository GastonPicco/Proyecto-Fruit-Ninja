using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceCleaner : MonoBehaviour
{
    public bool Particle;
    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -3)
        {
            Destroy(gameObject);
        }
        if (Particle)
        {
            Timer += Time.deltaTime;
            if(Timer > 3)
            {
                Destroy(gameObject);
            }
        }
        if (GameManager.data.reiniciar)
        {
            Destroy(gameObject);
        }
    }
}
