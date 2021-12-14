using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinZone : MonoBehaviour
{
    public int BoidsToWin;
    public int count = 0;
    public bool ToCombine = false;
    GameObject BoidLeader;
    Gamemanager gm;
    Boidhavior bl;
    bool won = false;
    public TextMeshProUGUI BoidsText;
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
        if (BoidsText != null)
        {
            if ((BoidsToWin - count) > 0)
                BoidsText.text = (BoidsToWin - count).ToString();
            else
                BoidsText.text = "0";
        }
    }

    void Win()
    {
        if (ToCombine == false)
        {
            gm.displayResults(count);
            gm.hideUI(4);
        }
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
