using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oilcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed= 10f;
    private Vector3 startposition;
    void Start()
    {
        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        if (transform.position.z == startposition.z)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false);
            float randomX = Random.Range(-5f, 5f);
            transform.position = new Vector3(randomX, transform.position.y, transform.position.z);
        }
    }
}
