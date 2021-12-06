using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    public int BoidsToWin;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= BoidsToWin)
        {
            Win();
        }
    }

    void Win()
    {
        Debug.Log("Boids Achived");
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
