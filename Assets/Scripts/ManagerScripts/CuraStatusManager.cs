using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CuraStatusManager : MonoBehaviour
{
   public UnityEngine.UI.Image CuraBarStatus;
    public TextMeshProUGUI levelCura;
    int progress = 0;
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
        CuraBarStatus.fillAmount = fillAmount;
        levelCura.text = progress.ToString();
    }

    IEnumerator ProgressOn()
    {
        while (progress < progressTotal)
        {
            yield return new WaitForSeconds(0.5f);
            progress ++;
            VerificaOProgresso();
        }

        void VerificaOProgresso()
        {
            if (progress == progressTotal)
            {
                progress = 0;
                Debug.Log("Voc� Achou A Cura");
            }
        }
    }
}
