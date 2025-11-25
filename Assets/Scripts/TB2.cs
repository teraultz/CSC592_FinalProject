using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TB2 : MonoBehaviour
{
    public GM2 gms;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            gms.points += 1;
            Destroy(other);
        }
    }
}
