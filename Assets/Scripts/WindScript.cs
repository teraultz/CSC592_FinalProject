using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    public Vector3 pushDirection = Vector3.forward;
    public float pushStrength = 5f;
    public ForceMode forceMode = ForceMode.Impulse;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null) {
            Vector3 force = pushDirection.normalized * pushStrength;
            rb.AddForce(force, forceMode);
        }
    }
}
