using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup2 : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject mainCamera;
    bool carrying;
    GameObject carriedObject;
    [SerializeField] float distance;
    void Start()
    {
        //mainCamera = GameObject.FindWithTag("PlayerCam");
        mainCamera = GameObject.Find("PlayerCam");
    }

    // Update is called once per frame
    void Update()
    {
        if (carrying)
        {
            carry(carriedObject);
            checkDrop();
        }
        else
        {
            pickup();
        }
    }
    void carry(GameObject o)
    {
        // o.GetComponent<Rigidbody>().isKinematic = false;
        o.GetComponent<Rigidbody>().freezeRotation = true;
        o.transform.position = mainCamera.transform.position + mainCamera.transform.forward * distance;
    }
    void pickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;
            float z = distance;
            //Ray ray = mainCamera.camera.ScreenPointToRay(new Vector3(x, y));
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y, z));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if (p != null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                }
            }
        }
    }

    void checkDrop()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            carrying = false;
            carriedObject.GetComponent<Rigidbody>().freezeRotation = false;
            carriedObject = null;
        }
    }

}

