using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineWinZones : MonoBehaviour
{
    public GameObject Zone1;
    public GameObject Zone2;
    WinZone zone1;
    WinZone zone2;
    Gamemanager gm;
    GameObject BoidLeader;
    Boidhavior bl;
    bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        BoidLeader = FindObjectOfType<Boidhavior>().gameObject;
        zone1 = Zone1.GetComponent<WinZone>();
        zone2 = Zone2.GetComponent<WinZone>();
        gm = BoidLeader.GetComponent<Gamemanager>();
        bl = BoidLeader.GetComponent<Boidhavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (zone1.count >= zone1.BoidsToWin && zone2.count >= zone2.BoidsToWin && win != true && bl.AmmountOfBoids == 0)
        {
            Win();
        }
    }
    void Win()
    {
        gm.displayResults(zone1.count + zone2.count);
        gm.hideUI(4);
    }
}
