using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrutSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] Frutas;
    [SerializeField] int dificultad, secuencia;
    [SerializeField] float timer, generalTimer, SpawnerTimeScale ,spawnerRate,addSpeedTimer,InicialSpawnerRate;
    void Start()
    {
        secuencia = 0;
        InicialSpawnerRate = spawnerRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.data.reiniciar)
        {
            Reset();
            generalTimer = 0;
            dificultad = 0;
            spawnerRate = InicialSpawnerRate;
            GameManager.data.reiniciar = false;
        }
        generalTimer += Time.deltaTime;
        timer += Time.deltaTime;
        addSpeedTimer += Time.deltaTime;
        if(generalTimer < 400)
        {
            if (addSpeedTimer > 45)
            {
                spawnerRate = spawnerRate * 0.98f;
                addSpeedTimer = 0;
            }
        }
        else
        {
            if(addSpeedTimer > 7)
            {
                spawnerRate = spawnerRate * 0.97f;
                addSpeedTimer = 0;
            }
        }


        if(timer > spawnerRate)
        {
            SpawnerTimeScale += Time.deltaTime;
            Dificultad();
            if (dificultad == 0)
            {
                Spawn();
                Reset();
            }
            else if (dificultad == 1)
            {
                if(secuencia == 0)
                {
                    Spawn();
                    secuencia += 1;
                }               
                if (SpawnerTimeScale > spawnerRate / 4 && secuencia == 1)
                {                  
                    Spawn();
                    Reset();
                }
            }
            else if (dificultad == 2)
            {

                if (secuencia == 0)
                {
                    Spawn();
                    secuencia += 1;
                }
                if (SpawnerTimeScale > spawnerRate / 4 && secuencia == 1)
                {
                    Spawn();
                    secuencia += 1;
                }
                if (SpawnerTimeScale > (spawnerRate / 4) * 2)
                {
                    Spawn();
                    Reset();
                }
            }
            else if (dificultad == 3)
            {

                if (secuencia == 0)
                {
                    Spawn();
                    secuencia += 1;
                }
                if (SpawnerTimeScale > spawnerRate / 4 && secuencia == 1)
                {
                    Spawn();
                    secuencia += 1;
                }
                if (SpawnerTimeScale > (spawnerRate / 4) * 2 && secuencia == 2)
                {
                    Spawn();
                    secuencia += 1;
                }
                if (SpawnerTimeScale > (spawnerRate / 4) * 3 && secuencia == 3)
                {
                    Spawn();
                    Reset();
                }
            }
            else if (dificultad == 4)
            {
                if (secuencia == 0)
                {
                    Spawn();
                    secuencia += 1;
                }
                if (SpawnerTimeScale > spawnerRate / 4 && secuencia == 1)
                {
                    Spawn();
                    secuencia += 1;
                }
                if (SpawnerTimeScale > (spawnerRate / 4) * 2 && secuencia == 2)
                {
                    Spawn();
                    secuencia += 1;
                }
                if (SpawnerTimeScale > (spawnerRate / 4) * 3 && secuencia == 3)
                {
                    Spawn();
                    secuencia += 1;
                }
                if (SpawnerTimeScale > (spawnerRate / 4) * 4 && secuencia == 4)
                {
                    Spawn();
                    Reset();
                }
            }
            else if (dificultad == 5)
            {
                if (secuencia == 0)
                {
                    Spawn();
                    secuencia += 1;
                }
                if (SpawnerTimeScale > spawnerRate / 4 && secuencia == 1)
                {
                    Spawn();
                    secuencia += 1;
                }
                if (SpawnerTimeScale > (spawnerRate / 4) * 2 && secuencia == 2)
                {
                    Spawn();
                    secuencia += 1;
                }
                if (SpawnerTimeScale > (spawnerRate / 4) * 3 && secuencia == 3)
                {
                    Spawn();
                    secuencia += 1;
                }
                if (SpawnerTimeScale > (spawnerRate / 4) * 4 && secuencia == 4)
                {
                    Spawn();
                    secuencia += 1;
                }
                if (SpawnerTimeScale > (spawnerRate / 4) * 5 && secuencia == 5)
                {
                    Spawn();
                    Reset();
                }
            }


        }

    }

    private void Dificultad()
    {
        if (generalTimer < 30)
        {
            dificultad = 0;
        }
        else if (generalTimer < 120)
        {
            dificultad = 1;
        }
        else if (generalTimer < 240)
        {
            dificultad = 2;
        }
        else if (generalTimer < 300)
        {
            dificultad = 3;
        }
        else if (generalTimer < 380)
        {
            dificultad = 4;
        }
        else
        {
            dificultad = 5;
        }
    }

    private void Spawn()
    {
        int randomnum = Random.Range(0, 101);
        if (randomnum < 82)
        {
            Instantiate(Frutas[0], gameObject.transform.position, Random.rotationUniform);
            GameManager.data.frutas = GameManager.data.frutas + 1;
        }
        else
        {
            Instantiate(Frutas[1], gameObject.transform.position, Random.rotationUniform);
            GameManager.data.bombas = GameManager.data.bombas + 1;
        }
    }
    private void Reset()
    {
        timer = 0;
        secuencia = 0;
        SpawnerTimeScale = 0;
    }
}
