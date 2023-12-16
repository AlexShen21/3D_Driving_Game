using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{

    private MeshRenderer Meshy;
    // Start is called before the first frame update
    void Start()
    {
        Meshy = GetComponent<MeshRenderer>();
        Meshy.material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnGreen()
    {
        Meshy.material.color = Color.green;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Meshy.material.color = Color.blue;
        Invoke("TurnGreen", 5.0f);
        //if (collision.gameObject.GetComponent<car_Controller>() != null)
        //{
        FindObjectOfType<car_Controller>().respawn = FindObjectOfType<car_Controller>().transform.position;
        FindObjectOfType<car_Controller>().respawnRot = FindObjectOfType<car_Controller>().transform.rotation;
        //}
    }
}
