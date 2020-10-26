using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositiveZ : MonoBehaviour
{
    public GameObject childObject;

    float forwardSpeed = 5.0f;
    //float rotationSpeed = 150.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 7)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
        }

        childObject.transform.Rotate(new Vector3(0f, 2.0f, 0f));
    }
}
