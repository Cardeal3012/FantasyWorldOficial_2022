using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Text digitalCock;

    private void LateUpdate()
    {
        CheckTime();
    }

    void CheckTime()
    {
        int horas   = Mathf.FloorToInt(DayNightCycle.instance.getTempoAtual);
        int minutos = Mathf.FloorToInt((DayNightCycle.instance.getTempoAtual - horas) * 60);

        if (minutos < 10) digitalCock.text = horas + " : 0" + minutos;
        else            { digitalCock.text = horas + " : "  + minutos; }
    }
}
