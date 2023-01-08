using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // READ ME https://imgur.com/a/x6hsDZq
    private GameObject player;
    [SerializeField] private string button;
    private bool isExit = false;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider player)
    {
        isExit = true;
    }

    private void Update()
    {
        if (isExit)
        {
            if (Input.GetKeyDown(button))
            {
                Debug.Log("Press \"" + button + "\" to exit");
                Application.Quit();
            }
        }
    }
}
