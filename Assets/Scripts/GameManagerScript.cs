using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public int points;
    public TextMeshProUGUI textmesh;
    public GameObject ballprefab;
    public Transform spawnpoint1;
    public Transform spawnpoint2;
    public Transform spawnpoint3;
    private int pointgoal;

    public GameObject victorycanvas;

    public AudioSource buttonpressaudio;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        pointgoal = 3;
        victorycanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        textmesh.text = $"Points: {points}/{pointgoal}";

        if (points == pointgoal){
            victorycanvas.SetActive(true);
        }
    }

    public void Testbutton()
    {
        Instantiate(ballprefab, spawnpoint1.position, spawnpoint1.rotation);
        Instantiate(ballprefab, spawnpoint2.position, spawnpoint2.rotation);
        Instantiate(ballprefab, spawnpoint3.position, spawnpoint3.rotation);
        buttonpressaudio.Play();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
