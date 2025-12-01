using Oculus.Interaction.Samples;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM3 : MonoBehaviour
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

    public GameObject binprefab;
    public Transform spot1;
    public Transform spot2;
    public Transform spot3;
    private Transform[] spots;
    private float timer = 0f;

    public GameObject victorycanvas;
    public GameObject scorecountcanvas;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        pointgoal = 1;

        spots = new Transform[] { spot1, spot2, spot3 };

        victorycanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //CANVAS CODE
        textmesh.text = $"Points: {points}/{pointgoal}";

        if (points == pointgoal)
        {
            scorecountcanvas.SetActive(false);
            victorycanvas.SetActive(true);
            FinishGame();

        }

        //FAN CODE
        float y = fan.transform.eulerAngles.y;

        if (y >= 359f || y < 1f)     
            goingUp = false;          

        if (y <= 275f)
            goingUp = true;           

        if (goingUp)
            fan.transform.Rotate(0, fanspeed * Time.deltaTime, 0);
        else
            fan.transform.Rotate(0, -fanspeed * Time.deltaTime, 0);

        //TELEPORTING CODE
        timer += Time.deltaTime;
        if (timer >= 5f)  
        {
            MoveBin();
            timer = 0f; 
        }
    }

    public void Testbutton()
    {
        Instantiate(ballprefab, spawnpoint1.position, spawnpoint1.rotation);
        Instantiate(ballprefab, spawnpoint2.position, spawnpoint2.rotation);
        Instantiate(ballprefab, spawnpoint3.position, spawnpoint3.rotation);
    }

    void MoveBin()
    {
        int index = UnityEngine.Random.Range(0, spots.Length); 
        binprefab.transform.position = spots[index].position;
    }

    public void FinishGame()
    {
        SceneManager.LoadScene(3);
    }
}
