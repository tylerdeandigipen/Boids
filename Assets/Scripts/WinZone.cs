using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    public int BoidsToWin;
    public int count = 0;
    GameObject BoidLeader;
    Gamemanager gm;
    bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        BoidLeader = FindObjectOfType<Boidhavior>().gameObject;
        gm = BoidLeader.GetComponent<Gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= BoidsToWin && won == false)
        {
            Win();
            won = true;
        }
    }

    void Win()
    {
        gm.currentLevel += 1;
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
