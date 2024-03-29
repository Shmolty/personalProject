using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDown : MonoBehaviour
{
    public float fallSpeed = -1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * fallSpeed * Time.deltaTime);

        if (transform.position.y < -1)
        {
            Destroy(gameObject);
        }
    }
}
