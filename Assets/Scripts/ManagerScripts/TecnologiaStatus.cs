using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TecnologiaStatus : MonoBehaviour
{
    public Image TecnologiaBarStatus;
    public TextMeshProUGUI levelTecnologico;
    int progress = 0;
    int levelTecnologia = 0;
    int progressTotal = 100;
    float fillAmount;
    public bool progressed = false;

    void Start()
    {
        StartCoroutine(ProgressOn());
        
    }

    void Update()
    {
        fillAmount = (float)progress / progressTotal;
        TecnologiaBarStatus.fillAmount = fillAmount;
        levelTecnologico.text = levelTecnologia.ToString();
    }

    IEnumerator ProgressOn()
    {
        while (progress < progressTotal)
        {
            yield return new WaitForSeconds(0.1f);
            progress++;
            VerificaOProgresso();
        }

        void VerificaOProgresso()
        {
            if (progress == progressTotal)
            {
                levelTecnologia++;
                progress = 0;
                Debug.Log("Você Achou A Cura");
            }
        }
    }
}
