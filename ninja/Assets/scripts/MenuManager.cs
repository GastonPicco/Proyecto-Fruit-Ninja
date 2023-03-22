using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject DificultyPanel;
    [SerializeField] GameObject CloseGamePanel;
    [SerializeField] GameObject ContadorPanel , ultimoPuntajePanel;
    [SerializeField] GameObject ReiniciarPanel;
    [SerializeField] GameObject CruzPanel;
    private float timeToLose;
    private bool playing;
    private int puntaje , UltimoPuntaje;
    [SerializeField] TextMeshProUGUI puntos , ultimosPuntos;
    [SerializeField] Button dificultad;
    [SerializeField] Volume volumen;
    private DepthOfField DOF;
    [SerializeField] GameObject[] cruz;
    private int errores;

    
    float timeScale;
    private Color colorDificultad;
    void Start()
    {
        playing = false;
        timeScale = 1.0f;
        colorDificultad = dificultad.GetComponent<Image>().color;     
    }

    void Update()
    {
        Errores();
        if (Input.GetKeyUp(KeyCode.Escape)&& !mainPanel.activeInHierarchy)
        {
            mainPanel.SetActive(true);
            DificultyPanel.SetActive(false);
            CloseGamePanel.SetActive(false);
            CruzPanel.SetActive(false);
            if (playing)
            {
                ReiniciarPanel.SetActive(true);
            }
        }
        else if(Input.GetKeyUp(KeyCode.Escape) && mainPanel.activeInHierarchy && !playing)
        {
            CruzPanel.SetActive(false);
            mainPanel.SetActive(false);
            DificultyPanel.SetActive(false);
            CloseGamePanel.SetActive(true);
            ReiniciarPanel.SetActive(false);
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && mainPanel.activeInHierarchy && playing)
        {
            mainPanel.SetActive(false);
            DificultyPanel.SetActive(false);
            CloseGamePanel.SetActive(false);
            ReiniciarPanel.SetActive(false);
            ReiniciarPanel.SetActive(false);
            CruzPanel.SetActive(true);
        }
        if (CloseGamePanel.activeInHierarchy)
        {
            ContadorPanel.SetActive(false);
            CruzPanel.SetActive(false);
        }
        else
        {
            ContadorPanel.SetActive(true);           
        }
        Pause();
        Puntaje();
    }

    public void _OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        DificultyPanel.SetActive(false);
        CloseGamePanel.SetActive(false);
        ultimoPuntajePanel.SetActive(false);
        panel.SetActive(true);
    }
    public void _Start(GameObject panelJugar)
    {
        panelJugar.SetActive(false);
        ultimoPuntajePanel.SetActive(false);
    }
    public void _ClosePanel(GameObject panelToClose)
    {
        panelToClose.SetActive(false);
    }

    public void Pause()
    {
        if(mainPanel.activeInHierarchy || DificultyPanel.activeInHierarchy || CloseGamePanel.activeInHierarchy)
        {
            Time.timeScale = 0;
            volumen.profile.TryGet(out DOF);
            {
                DOF.active = true;
            }
            CruzPanel.SetActive(false);
        }
        else
        {
            Time.timeScale = timeScale;
            volumen.profile.TryGet(out DOF);
            {
                DOF.active = false;
            }
            CruzPanel.SetActive(true);
        }
    }

    public void Puntaje()
    {
        puntaje = GameManager.data.puntos;
        puntos.SetText(puntaje+"");
    }

    public void Playing()
    {
        playing = true;
        dificultad.GetComponent<Button>().interactable = false;
        dificultad.GetComponent<Image>().color = Color.gray;
    }

    public void Reiniciar()
    {
        GameManager.data.reiniciar = true;
        GameManager.data.puntos = 0;
        GameManager.data.errores = 0;
        Puntaje();
        playing = false;
        dificultad.GetComponent<Button>().interactable = true;
        dificultad.GetComponent<Image>().color = colorDificultad;
        cruz[0].SetActive(false);
        cruz[1].SetActive(false);
        cruz[2].SetActive(false);
    }

    public void Errores()
    {
        errores = GameManager.data.errores;
        if(errores >= 1)
        {
            cruz[0].SetActive(true);
        }
        if(errores >= 2)
        {
            cruz[1].SetActive(true);
        }
        if(errores >= 3)
        {
            cruz[2].SetActive(true);
        }
        if(errores >= 4)
        {
            timeToLose += Time.deltaTime;
            if (timeToLose > 1.2)
            {
                UltimoPuntaje = puntaje;
                ultimosPuntos.SetText(UltimoPuntaje + "");
                ultimoPuntajePanel.SetActive(true);
                Reiniciar();
                mainPanel.SetActive(true);
                ReiniciarPanel.SetActive(false);
                
                timeToLose = 0;
            }
            
         
        }
    }
    public void quitGame()
    {
        Application.Quit();
    }


}
