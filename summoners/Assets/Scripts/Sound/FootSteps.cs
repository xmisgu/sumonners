using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps: MonoBehaviour
{
    public AudioSource footstepSound;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            footstepSound.enabled = true;
        }
        else
        {
            footstepSound.enabled = false;
        }
    }
}
