using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GM2 : MonoBehaviour
{
    public int points;
    public TextMeshProUGUI textmesh;
    public GameObject ballprefab;
    public Transform spawnpoint1;
    public Transform spawnpoint2;
    public Transform spawnpoint3;
    private int pointgoal;

    public GameObject fan;
    public float fanspeed = 10f;
    private bool goingUp = true;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        pointgoal = 5;
    }

    // Update is called once per frame
    void Update()
    {
        textmesh.text = $"Points: {points}/{pointgoal}";

        float y = fan.transform.eulerAngles.y;

        // --- Change direction at limits ---
        if (y >= 359f || y < 1f)      // 360° wrap-around handled
            goingUp = false;          // start rotating DOWN

        if (y <= 275f)
            goingUp = true;           // rotate UP again

        // --- Rotate ---
        if (goingUp)
            fan.transform.Rotate(0, fanspeed * Time.deltaTime, 0);
        else
            fan.transform.Rotate(0, -fanspeed * Time.deltaTime, 0);
    }

    public void Testbutton()
    {
        Instantiate(ballprefab, spawnpoint1.position, spawnpoint1.rotation);
        Instantiate(ballprefab, spawnpoint2.position, spawnpoint2.rotation);
        Instantiate(ballprefab, spawnpoint3.position, spawnpoint3.rotation);
    }
}
