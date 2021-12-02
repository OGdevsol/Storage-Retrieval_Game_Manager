using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinMove : MonoBehaviour
{
    public float rotationVal=50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotationVal*Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            Destroy(gameObject);
            Gameplay_Manager.instance.increment();
        }
    }
}
