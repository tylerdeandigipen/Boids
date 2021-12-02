using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public GameObject MainMenu;
    Boidhavior BoidLeader;
    public GameObject Boid;
    public GameObject Avoid;    
    GameObject CurrentSpawnable;
    // Start is called before the first frame update
    void Start()
    {
        CurrentSpawnable = Boid;
        BoidLeader = FindObjectOfType<Boidhavior>();
        MainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        
    }
    public void SetSpawnBoids(string useless)
    {
        CurrentSpawnable = Boid;
    }
    public void SetSpawnAvoids(string useless)
    {
        CurrentSpawnable = Avoid;
    }
    void ProcessInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BoidLeader.UnfreezeBoids();
            MainMenu.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float mouseX = worldPosition.x;
            float mouseY = worldPosition.y;
            Instantiate(CurrentSpawnable, new Vector3(mouseX, mouseY, 0), new Quaternion());
        }    
        if (Input.mouseScrollDelta != new Vector2(0, 0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float mouseX = worldPosition.x;
            float mouseY = worldPosition.y;
            Instantiate(Boid, new Vector3(mouseX, mouseY, 0), new Quaternion());
        }
    }
}
