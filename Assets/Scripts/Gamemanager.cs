using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public bool canSpawn = true;
    public int AvoidsAmmount;
    public int BoidsAmmount;
    public int AttractAmmount;
    public bool Undo = false;
    List<GameObject> obj = new List<GameObject>();
    public GameObject ButtonUI;
    public GameObject ButtonUICampaign;
    public GameObject LevelSelect;
    public GameObject LevelComplete;
    public TextMeshProUGUI BoidsLeft;
    public TextMeshProUGUI FactBox;
    int totalPossibleBoids;
    public TextMeshProUGUI AvoidsUsed;
    bool canPlace = true;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    public GameObject level6;
    public GameObject level7;
    public GameObject level8;
    public GameObject level9;
    public GameObject level10;
    public GameObject level11;
    public GameObject level12;
    public GameObject level13;
    public GameObject level14;
    public GameObject level15;
    public GameObject level16;
    bool isSandBox = false;
    public bool allowPlaceAfterManualreset = false;
    bool canSpam = false;
    level levelscript;
    
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
        LevelSelect.SetActive(false);
        ButtonUICampaign.SetActive(false);
        LevelComplete.SetActive(false);
        SpawnCountGiven[0] = BoidsAmmount;
        SpawnCountGiven[1] = AvoidsAmmount + 1;
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
        if (Input.GetKeyUp(KeyCode.Mouse1) && canPlace == true)
        {
            FactRandomizer factscript = this.GetComponent<FactRandomizer>();
            factscript.FactRandomize(FactBox);
        }
        if (isSandBox == true)
        {            
            canPlace = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && canPlace == true)
        {
            //if(levelscript != null && CurrentSpawnableID != 9999)
              //  SpawnCountGiven[CurrentSpawnableID] = levelscript.avoidsAmmount;
            if (canSpawn == true && CurrentSpawnableID != 9999 && SpawnCount[CurrentSpawnableID] < SpawnCountGiven[CurrentSpawnableID])
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
                    GameObject tempObj = Instantiate(CurrentSpawnable, new Vector3(mouseX, mouseY, 0), new Quaternion());
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

        if (Undo == true && BoidLeader.isFrozen == true)
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
        else
            Undo = false;
  
        if (Input.mouseScrollDelta != new Vector2(0, 0) && canSpam == true)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float mouseX = worldPosition.x;
            float mouseY = worldPosition.y;
            Instantiate(Boid, new Vector3(mouseX, mouseY, 0), new Quaternion());
        }
        if (allowPlaceAfterManualreset == true)
        {
            canSpawn = true;
            allowPlaceAfterManualreset = false;
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
    public void hideUI(int id)
    {
        switch (id)
        {
            case 1:
                if (ButtonUI.activeSelf == true)
                {
                    ButtonUI.SetActive(false);
                }
                else
                    ButtonUI.SetActive(true);
                break;
            case 2:
                if (ButtonUICampaign.activeSelf == true)
                {
                    ButtonUICampaign.SetActive(false);
                }
                else
                    ButtonUICampaign.SetActive(true);
                break;
            case 3:
                if (LevelSelect.activeSelf == true)
                {
                    LevelSelect.SetActive(false);
                }
                else
                    LevelSelect.SetActive(true);
                break;
            case 4:
                if (LevelComplete.activeSelf == true)
                {
                    LevelComplete.SetActive(false);
                    
                }
                else
                    LevelComplete.SetActive(true);
                    FactRandomizer factscript = this.GetComponent<FactRandomizer>();
                    factscript.FactRandomize(FactBox);
                break;

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

    public void undo()
    {
        Undo = true;
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

    public void startStop()
    {
        if (BoidLeader.isFrozen == true)
        {
            startSim();
        }
        else
            restartLevel();
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
        BoidLeader.totalBoids = 0;
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
    public void reloadMenu()
    {
        resetSimulation();
        level levelScript = FindObjectOfType<level>();
        if (levelScript != null)
        {
            Destroy(levelScript.gameObject);
        }
        BoidLeader.FreezeBoids();
        ButtonUI.SetActive(false);
        ButtonUICampaign.SetActive(false);
        LevelSelect.SetActive(false);
        LevelComplete.SetActive(false);
        MainMenu.SetActive(true);
        CurrentSpawnableID = 9999;
    }

    public void displayResults(int count)
    {
        totalPossibleBoids = BoidLeader.GetComponent<Boidhavior>().totalBoids;
        Avoid[] objectsToAvoid;
        objectsToAvoid = FindObjectsOfType<Avoid>();
        int avoidscount = objectsToAvoid.Length;
        BoidsLeft.text = count.ToString() + "/" + totalPossibleBoids.ToString();
        AvoidsUsed.text = avoidscount.ToString();
    }

    public void CheckLevelID(int id)
    {
        if (id == 9999)
        {
            currentLevel += 1;
        }
        else
            currentLevel = id;
        switch (currentLevel)
        {
            case 1:
                if (level1 != null)
                {
                    CurrentLevel = level1;
                    level levelscript = level1.GetComponent<level>();
                    SpawnCountGiven[1] = levelscript.avoidsAmmount;
                }
                break;
            case 2:
                if(level2 != null)
                { 
                    CurrentLevel = level2;
                    level levelscript = level2.GetComponent<level>();
                    SpawnCountGiven[1] = levelscript.avoidsAmmount;
                }

                break;
            case 3:
                if (level3 != null)
                { 
                    CurrentLevel = level3;
                    level levelscript = level3.GetComponent<level>();
                    SpawnCountGiven[1] = levelscript.avoidsAmmount;
                }
                break;
            case 4:
                if (level4 != null)
                { 
                    CurrentLevel = level4;
                    level levelscript = level4.GetComponent<level>();
                    SpawnCountGiven[1] = levelscript.avoidsAmmount;
                }
                break;
            case 5:
                if (level5 != null)
                { 
                    CurrentLevel = level5;
                    level levelscript = level5.GetComponent<level>();
                    SpawnCountGiven[1] = levelscript.avoidsAmmount;
                }
                break;
            case 6:
                if (level6 != null)
                {
                    CurrentLevel = level6;
                    level levelscript = level6.GetComponent<level>();
                    SpawnCountGiven[1] = levelscript.avoidsAmmount;
                }
                break;
            case 7:
                if (level7 != null)
                {
                    CurrentLevel = level7;
                    level levelscript = level7.GetComponent<level>();
                    SpawnCountGiven[1] = levelscript.avoidsAmmount;
                }
                break;
            case 8:
                if (level8 != null)
                {
                    CurrentLevel = level8;
                    level levelscript = level8.GetComponent<level>();
                    SpawnCountGiven[1] = levelscript.avoidsAmmount;
                }
                break;
            case 9:
                if (level9 != null)
                {
                    CurrentLevel = level9;
                    level levelscript = level9.GetComponent<level>();
                    SpawnCountGiven[1] = levelscript.avoidsAmmount;
                }
                break;
            case 10:
                if (level10 != null)
                {
                    CurrentLevel = level10;
                    level levelscript = level10.GetComponent<level>();
                    SpawnCountGiven[1] = levelscript.avoidsAmmount;
                }
                break;
            case 11:
                if (level11 != null)
                {
                    CurrentLevel = level11;
                    level levelscript = level11.GetComponent<level>();
                    SpawnCountGiven[1] = levelscript.avoidsAmmount;
                }
                break;
            case 12:
                if (level12 != null)
                {
                    CurrentLevel = level12;
                    level levelscript = level12.GetComponent<level>();
                    SpawnCountGiven[1] = levelscript.avoidsAmmount;
                }
                break;
            case 13:
                if (level13 != null)
                {
                    CurrentLevel = level13;
                    level levelscript = level13.GetComponent<level>();
                    SpawnCountGiven[1] = levelscript.avoidsAmmount;
                }
                break;
            case 14:
                if (level14 != null)
                {
                    CurrentLevel = level14;
                    level levelscript = level14.GetComponent<level>();
                    SpawnCountGiven[1] = levelscript.avoidsAmmount;
                }
                break;
            case 15:
                if (level15 != null)
                {
                    CurrentLevel = level15;
                    level levelscript = level15.GetComponent<level>();
                    SpawnCountGiven[1] = levelscript.avoidsAmmount;
                }
                break;
            case 16:
                if (level16 != null)
                {
                    CurrentLevel = level16;
                    level levelscript = level16.GetComponent<level>();
                    SpawnCountGiven[1] = levelscript.avoidsAmmount;
                }
                break;
        }        
    }
}



