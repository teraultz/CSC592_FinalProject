using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heighttest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject body;
    public Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if (body != null)
        {
            body.transform.position = transform.position + offset;
            //body.transform.rotation = transform.rotation;
        }
    }
}
