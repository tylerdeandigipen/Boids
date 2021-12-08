using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject MainMenu;
    public int currentLevel = 1;
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
    public bool Undo = false;
    List<GameObject> obj = new List<GameObject>();
    public GameObject ButtonUI;
    bool canPlace = true;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    bool isSandBox = false;
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentLevel = level1;
        Canvas.SetActive(true);
        CurrentSpawnable = Boid;
        CurrentSpawnableID = 9999;
        BoidLeader = FindObjectOfType<Boidhavior>();
        MainMenu.SetActive(true);
        ButtonUI.SetActive(false);
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
        if (isSandBox == true)
        {            
            canPlace = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && canPlace == true)
        {
            if (canSpawn == true && CurrentSpawnableID != 9999 &&SpawnCount[CurrentSpawnableID] < SpawnCountGiven[CurrentSpawnableID])
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
                    GameObject tempObj = Instantiate(CurrentSpawnable, new Vector3(mouseX, mouseY, 0), new Quaternion());
                    obj.Add(tempObj);
                    SpawnCount[CurrentSpawnableID] += 1;
                }
            }
            else
                canSpawn = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1) && canPlace == true)
        {
            Undo = true;
        }

        if (Undo == true)
        {
            for (int i = 0; i <= obj.Count; i++)
            {
                if (i == obj.Count && obj.Count != 0)
                {
                    GameObject temp = obj[i - 1];
                    obj.RemoveAt(i - 1);
                    Destroy(temp);
                    SpawnCount[CurrentSpawnableID] -= 1;
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
        CheckLevelID(currentLevel);
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
        canPlace = true;
    }
    public void hideUI()
    {
        if (ButtonUI.activeSelf == true)
        {
            ButtonUI.SetActive(false);
        }
        else
            ButtonUI.SetActive(true);
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
    public void hideMenu()
    {
        if (MainMenu.activeSelf == true)
        {
            MainMenu.SetActive(false);
        }
        else
            MainMenu.SetActive(true);
    }
    public void startSim()
    {
        BoidLeader.UnfreezeBoids();
        canPlace = false;
    }

    public void restartLevel()
    {
        level levelScript = FindObjectOfType<level>();
        if (levelScript != null)
        {
            Destroy(levelScript.gameObject);
        }
        BoidLeader.FreezeBoids();
        if (isSandBox != true)
        {
            Instantiate(CurrentLevel);
        }
        canPlace = true;
    }
    public void startSandbox()
    {
        isSandBox = true;
        SpawnCountGiven[0] = 9999;
        SpawnCountGiven[1] = 9999;
        SpawnCountGiven[2] = 9999;

    }
    public void startCampaign()
    {
        isSandBox = false;
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
        if (isSandBox != true)
        {
            Instantiate(CurrentLevel);
        }
        canPlace = true;
    }
    void CheckLevelID(int id)
    {
        switch (id)
        {
            case 1:
                if (level1 != null)
                    CurrentLevel = level1;
                break;
            case 2:
                if(level2 != null)
                    CurrentLevel = level2;
                break;
            case 3:
                if (level3 != null)
                    CurrentLevel = level3;
                break;
            case 4:
                if (level4 != null)
                    CurrentLevel = level4;
                break;
            case 5:
                if (level5 != null)
                    CurrentLevel = level5;
                break;

        }
    }
}



