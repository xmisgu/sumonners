using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationCamerasHandler : MonoBehaviour
{
    [SerializeField] GameObject CameraLvl1;
    [SerializeField] AudioSource portalSound;
    private void OnEnable()
    {
        Debug.Log(":aekfgjhsdkjhfdshbf");
        CameraLvl1.SetActive(true);
        portalSound.enabled = true;
    }

    private void OnDisable()
    {
        CameraLvl1.SetActive(false);
        portalSound.enabled = false;
    }
}
