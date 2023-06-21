using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menulvlitem : MonoBehaviour
{
        [SerializeField] private GameObject item1;
    // Start is called before the first frame update
    void Start()
    {
        item1.SetActive(false);
    }

}
