using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapsFuction : MonoBehaviour
{
    public GameObject HudInGame;
    public GameObject HudInMaps;

    public GameObject MainCamera;
    public GameObject MapsCamera;

    bool map_enabled = false;

    public void EnableOrDisableMaps() 
    {
        map_enabled = !map_enabled;

        MainCamera.SetActive(!map_enabled);
        HudInGame.SetActive(!map_enabled);

        MapsCamera.SetActive(map_enabled);
        HudInMaps.SetActive(map_enabled);
    }
}
