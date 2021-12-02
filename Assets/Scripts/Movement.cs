using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int BoidSpam;
    public GameObject Player;
    public int movSpeed;
    public Rigidbody2D rb;
    private Vector2 movDir;
    public GameObject Boid;
    public GameObject Avoid;
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Rotate();
    }

    private void FixedUpdate()
    {
        move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        movDir = new Vector2(moveX, moveY);
    }

    void move()
    {
        rb.velocity = new Vector2(movDir.x * movSpeed, movDir.y * movSpeed);
    }

    void Rotate()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(worldPosition.y - Player.transform.position.y, worldPosition.x - Player.transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation1 = Quaternion.Euler(0, 0, angle);
        Player.transform.rotation = rotation1;
    }
}
