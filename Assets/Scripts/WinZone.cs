using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    public int BoidsToWin;
    public int count = 0;
    GameObject BoidLeader;
    Gamemanager gm;
    Boidhavior bl;
    bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        BoidLeader = FindObjectOfType<Boidhavior>().gameObject;
        gm = BoidLeader.GetComponent<Gamemanager>();
        bl = BoidLeader.GetComponent<Boidhavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= BoidsToWin && won == false && bl.AmmountOfBoids == 0)
        {
            Win();
            won = true;
        }
        else if (bl.AmmountOfBoids == 0 && bl.isFrozen == false)
        {
            gm.allowPlaceAfterManualreset = true;
            gm.restartLevel();
        }
    }

    void Win()
    {
        gm.currentLevel += 1;
        gm.CheckLevelID(gm.currentLevel);
        gm.allowPlaceAfterManualreset = true;
        gm.resetLevel();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "boid")
        {
            Destroy(collision.gameObject);
        }
        count += 1;
    }
}
