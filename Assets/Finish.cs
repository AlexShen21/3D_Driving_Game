using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private MeshRenderer Meshy;
    // Start is called before the first frame update
    void Start()
    {
        Meshy = GetComponent<MeshRenderer>();
        Meshy.material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        var car = FindObjectOfType<car_Controller>();
        if (car.StartPos != car.respawn)
        {
            car.Lap += 1;
        }
    }
}
