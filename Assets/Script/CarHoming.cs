using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHoming : MonoBehaviour
{
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terrain"))
        {
            GameManager.instance.flag = false;
            parent.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameManager.instance.flag = true;
    }
}
