using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 20f;
    public float minZ;
    public GameObject oil;
    private Vector3 startposition;
    public carcontroller carController;
    public GameObject vehicle;
    public float changeSpeed = 1f;
    void Start()
    {
        startposition = new Vector3(transform.position.x ,transform.position.y, 116f);
        carController = vehicle.GetComponent<carcontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * moveSpeed *Time.deltaTime;
        moveSpeed += changeSpeed * Time.deltaTime;

        if (carController != null && carController.oil < 0 && moveSpeed > 0)
        {
            moveSpeed -= 0.1f;
        }
        if (transform.position.z < minZ)
        {
           transform.position = startposition;
            if (!oil.activeSelf)
            {

                oil.SetActive(true);
            }
        }
    }
}
