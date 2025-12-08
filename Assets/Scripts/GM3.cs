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
    public GameObject fan2;
    public GameObject fan3;
    public float fanspeed = 10f;
    private bool goingUp = true;
    private bool goingUp2 = true;
    private bool goingUp3 = true;

    public GameObject binprefab;
    public Transform spot1;
    public Transform spot2;
    public Transform spot3;
    private Transform[] spots;
    private float timer = 0f;

    public GameObject victorycanvas;
    public GameObject scorecountcanvas;
    public AudioSource buttonpressaudio;
    public AudioSource teleport;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        pointgoal = 1;

        spots = new Transform[] { spot1, spot2, spot3 };

        victorycanvas.SetActive(false);
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
            //FinishGame();

        }

        //FAN1 CODE
        float y = fan.transform.eulerAngles.y;

        if (y >= 359f || y < 1f)     
            goingUp = false;          

        if (y <= 275f)
            goingUp = true;           

        if (goingUp)
            fan.transform.Rotate(0, fanspeed * Time.deltaTime, 0);
        else
            fan.transform.Rotate(0, -fanspeed * Time.deltaTime, 0);

        //FAN2 CODE
        float yy = fan2.transform.eulerAngles.y;

        if (yy > 180f) yy -= 360f;

        if (yy >= 90f)
            goingUp2 = false;

        if (yy <= 0f)
            goingUp2 = true;

        if (goingUp2)
            fan2.transform.Rotate(0, fanspeed * Time.deltaTime, 0);
        else
            fan2.transform.Rotate(0, -fanspeed * Time.deltaTime, 0);

        //FAN3 CODE
        float yyy = fan3.transform.eulerAngles.y;

        if (yyy > 180f) 
            yyy -= 360f;

        if (yyy >= 179f)
            goingUp3 = false;

        if (yyy <= 90f)
            goingUp3 = true;

        if (goingUp3)
            fan3.transform.Rotate(0, fanspeed * Time.deltaTime, 0);
        else
            fan3.transform.Rotate(0, -fanspeed * Time.deltaTime, 0);

        //TELEPORTING CODE
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            MoveBin();
            teleport.Play();
            timer = 0f;
        }

        //TELEPORTING CODE
        timer += Time.deltaTime;
        if (timer >= 5f)  
        {
            MoveBin();
            teleport.Play();
            timer = 0f; 
        }
    }

    public void Testbutton()
    {
        Instantiate(ballprefab, spawnpoint1.position, spawnpoint1.rotation);
        Instantiate(ballprefab, spawnpoint2.position, spawnpoint2.rotation);
        Instantiate(ballprefab, spawnpoint3.position, spawnpoint3.rotation);
        buttonpressaudio.Play();
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
