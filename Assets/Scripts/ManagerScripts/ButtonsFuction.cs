using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonsFuction : MonoBehaviour
{
    public GameObject Maps;
    public GameObject CameraMain;
    public GameObject HudMap;
    public GameObject HudGame;

    bool enabled = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) 
        {
            EnabledMaps();
        }
    }
    public void EnabledMaps() 
    {
        enabled = !enabled;

        Maps.SetActive(enabled);
        CameraMain.SetActive(!enabled);
        HudGame.SetActive(!enabled);
        HudMap.SetActive(enabled);
    }
}
