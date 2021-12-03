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
    public GameObject Attract;
    GameObject CurrentSpawnable;
    bool canSpawn = true;
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
    public void SetSpawnAttract(string useless)
    {
        CurrentSpawnable = Attract;
    }
    void ProcessInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // BoidLeader.UnfreezeBoids();
            //MainMenu.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (canSpawn == true)
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float mouseX = worldPosition.x;
                float mouseY = worldPosition.y;
                if (CurrentSpawnable == Attract)
                {
                    Movement AttractAble = FindObjectOfType<Movement>();
                    if (AttractAble != null)
                    {
                        Destroy(AttractAble.gameObject);
                    }
                }
                Instantiate(CurrentSpawnable, new Vector3(mouseX, mouseY, 0), new Quaternion());
            }
            else
                canSpawn = true;
        }
  
        if (Input.mouseScrollDelta != new Vector2(0, 0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float mouseX = worldPosition.x;
            float mouseY = worldPosition.y;
            Instantiate(Boid, new Vector3(mouseX, mouseY, 0), new Quaternion());
        }
    }
    public void resetSimulation()
    {
        Boid[] objects;
        Avoid[] objectsToAvoid;
        objects = FindObjectsOfType<Boid>();
        objectsToAvoid = FindObjectsOfType<Avoid>();
        Movement FollowObjectScript = FindObjectOfType<Movement>();   
        if (FollowObjectScript != null)
        {
            Destroy(FollowObjectScript.gameObject);
        }
        for (int i = 0; i < objects.Length; i++)
        {
            Destroy(objects[i].gameObject);
        }
        for (int i = 0; i < objectsToAvoid.Length; i++)
        {
            Destroy(objectsToAvoid[i].gameObject);
        }
    }
    public void stopSpawns()
    {
        canSpawn = false;
    }
    public void startSpawns()
    {
        canSpawn = true;
    }

    public void startSim()
    {
        BoidLeader.UnfreezeBoids();
        MainMenu.SetActive(false);
    }
}


