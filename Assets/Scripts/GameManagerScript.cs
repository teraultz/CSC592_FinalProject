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

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        pointgoal = 1;
    }

    // Update is called once per frame
    void Update()
    {
        textmesh.text = $"Points: {points}/{pointgoal}";

        if (points == pointgoal){
            SceneManager.LoadScene(1);
        }
    }

    public void Testbutton()
    {
        Instantiate(ballprefab, spawnpoint1.position, spawnpoint1.rotation);
        Instantiate(ballprefab, spawnpoint2.position, spawnpoint2.rotation);
        Instantiate(ballprefab, spawnpoint3.position, spawnpoint3.rotation);
    }
}
