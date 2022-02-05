using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour{
    
    [SerializeField]
    float duracaoDia_horas;
    [SerializeField]
    float duracaoDia_minutos;
    [SerializeField]
    float duracaoDia_segundos;

    [SerializeField]
    float duracaoTotalDia_segundos;
    [SerializeField]
    float velocidadeRotacao;
    [SerializeField]
    float tempoAtual;
    float rotacaoAtual;

    GameObject eixoDeRotacao;
    Light sun;
    Light moon;

    public static DayNightCycle instance;

    private void Awake()
    {instance = this;}

    private void Start()
    {
        // Encontrar e resetar objeto do eixo de rotação
        eixoDeRotacao = GameObject.FindGameObjectWithTag("EixoDoSol");
        eixoDeRotacao.transform.position = Vector3.zero;

        // Encontrar as fontes de luz do sol e da lua
        sun  = GameObject.FindGameObjectWithTag("Sun").GetComponent<Light>();
        moon = GameObject.FindGameObjectWithTag("Moon").GetComponent<Light>();

        //
        rotacaoAtual = tempoAtual*360/24;
        eixoDeRotacao.transform.Rotate(new Vector3(rotacaoAtual, 0, 0));
    }

    private void LateUpdate()
    {
        // Calcular velocidade de rotação
        duracaoTotalDia_segundos = duracaoDia_segundos;
        duracaoTotalDia_segundos += 60 * duracaoDia_minutos;
        duracaoTotalDia_segundos += 60 * 60 * duracaoDia_horas;

        velocidadeRotacao = 360 / duracaoTotalDia_segundos * Time.deltaTime;
        
        // Rotacionar o eixo do sol e da lua, de acordo com a velocidade de rotação
        eixoDeRotacao.transform.Rotate(velocidadeRotacao, 0, 0);
        rotacaoAtual     += velocidadeRotacao;
        if (rotacaoAtual > 360) rotacaoAtual -= 360;
        tempoAtual = (rotacaoAtual + 180)*24/360;
        if (tempoAtual > 24) tempoAtual -= 24;
    }


    private void SunsetSunrise()
    {
        if (tempoAtual > 17)
        {
            sun.intensity  = .5f * (tempoAtual / 18);
            moon.intensity = .3f * (tempoAtual / 20);
        }
    }

    // ========== ========== ========== ========== ==========
    // GETTERS & SETTERS
    public float getTempoAtual
    {
        get { return tempoAtual; }
        set { tempoAtual = value; }
    }
}
