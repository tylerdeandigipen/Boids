using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject MainMenu;
    Boidhavior BoidLeader;
    public GameObject Boid;
    public GameObject Avoid;
    public GameObject Attract;
    GameObject CurrentSpawnable;
    int CurrentSpawnableID;
    int[] SpawnCount = new int[3];
    int[] SpawnCountGiven = new int[3];
    GameObject CurrentLevel;
    bool canSpawn = true;
    public int AvoidsAmmount;
    public int BoidsAmmount;
    public int AttractAmmount;
    public GameObject level1;
    public bool Undo = false;
    List<GameObject> obj = new List<GameObject>(); 
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentLevel = level1;
        Canvas.SetActive(true);
        CurrentSpawnable = Boid;
        BoidLeader = FindObjectOfType<Boidhavior>();
        MainMenu.SetActive(true);
        SpawnCountGiven[0] = BoidsAmmount;
        SpawnCountGiven[1] = AvoidsAmmount;
        SpawnCountGiven[2] = AttractAmmount;
        for (int i = 0; i < 3; i++)
        {
            SpawnCount[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        
    }
    public void SetSpawnBoids(string useless)
    {
        CurrentSpawnable = Boid;
        CurrentSpawnableID = 0;        
    }
    public void SetSpawnAvoids(string useless)
    {
        CurrentSpawnable = Avoid;
        CurrentSpawnableID = 1;
    }
    public void SetSpawnAttract(string useless)
    {
        CurrentSpawnable = Attract;
        CurrentSpawnableID = 2;
    }
    void ProcessInputs()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (canSpawn == true && SpawnCount[CurrentSpawnableID] < SpawnCountGiven[CurrentSpawnableID])
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
                else
                {
                    Instantiate(CurrentSpawnable, new Vector3(mouseX, mouseY, 0), new Quaternion());
                    GameObject tempObj = Instantiate(CurrentSpawnable, new Vector3(mouseX, mouseY, 0), new Quaternion());
                    obj.Add(tempObj);
                    SpawnCount[CurrentSpawnableID] += 1;
                }
            }
            else
                canSpawn = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Undo = true;
        }

        if (Undo == true)
        {
            for (int i = 0; i <= obj.Count; i++)
            {
                if (i == obj.Count && obj.Count != 0)
                {
                    Debug.Log("bang");
                    Destroy(obj[i - 1]);
                    obj.RemoveAt(i - 1);
                }
            }
            Undo = false;
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
        WinZone WinZoneScript = FindObjectOfType<WinZone>();
        if (FollowObjectScript != null)
        {
            Destroy(FollowObjectScript.gameObject);
        }
        if (WinZoneScript != null)
        {
            Destroy(WinZoneScript.gameObject);
        }
        for (int i = 0; i < objects.Length; i++)
        {
            Destroy(objects[i].gameObject);
        }
        for (int i = 0; i < objectsToAvoid.Length; i++)
        {
            Destroy(objectsToAvoid[i].gameObject);
        }
        for (int i = 0; i < 3; i++)
        {
            SpawnCount[i] = 0;
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

    public void pauseSim()
    { 
    
    }
    public void startSim()
    {
        BoidLeader.UnfreezeBoids();
        MainMenu.SetActive(false);
    }

    public void restartLevel()
    {
        level levelScript = FindObjectOfType<level>();
        if (levelScript != null)
        {
            Destroy(levelScript.gameObject);
        }
        BoidLeader.FreezeBoids();
        Instantiate(CurrentLevel);
    }
    public void resetLevel()
    {
        resetSimulation();
        level levelScript = FindObjectOfType<level>();
        if (levelScript != null)
        {
            Destroy(levelScript.gameObject);
        }        
        BoidLeader.FreezeBoids();
        Instantiate(CurrentLevel);
    }
}


