using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager data;
    public CameraShake cameraShake;
    public int frutas , bombas , puntos, errores;
    public bool reiniciar, error;

    private void Awake()
    {
        if (data == null)
        {
            data = this;
        }
        else
        {
            if (data==this)
            {

            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    private void Update()
    {
        if (error)
        {
            StartCoroutine (cameraShake.Shake(0.5f,0.2f));
            error = false;
        }
    }

}
