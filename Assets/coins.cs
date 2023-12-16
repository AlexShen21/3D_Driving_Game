using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
    private MeshRenderer Meshy;
    private Vector3 StartPos;
    private bool Below;
    private Vector3 AddPos;

    // Start is called before the first frame update
    void Start()
    {
        Meshy = GetComponent<MeshRenderer>();
        Meshy.material.color = Color.yellow;
        StartPos = transform.position;
        Below = false;
        AddPos = new Vector3(0.0f, 0.0f, .03f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < StartPos.z - 5)
        {
            Below = true;
        }
        else if (transform.position.z > StartPos.z + 5)
        {
            Below = false;
        }
        if (Below)
        {
            transform.position = transform.position + AddPos;
        }
        else
        {
            transform.position = transform.position - AddPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<car_Controller>().Coins += 1;
        Destroy(gameObject);
    }
}
