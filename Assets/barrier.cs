using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{

    private MeshRenderer Meshy;
    // Start is called before the first frame update
    void Start()
    {
        Meshy = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnWhite()
    {
        Meshy.material.color = Color.white;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Meshy.material.color = Color.red;
        Invoke("TurnWhite", 5.0f);
        FindObjectOfType<car_Controller>().RestartCar();
    }
}
