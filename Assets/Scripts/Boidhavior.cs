using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boidhavior : MonoBehaviour
{
    public float CohesionWeight = 1;
    public float AlignmentWeight = 1;
    public float SeparationWeight = 1;
    public float FollowWeight = .5f;
    public float AvoidanceWeight = 1;
    public float PreviousSpeedWeight = 1;
    public float maxSpeed = 15;
    public float minSpeed = 5;
    public float FriendRange = 5;
    public float SeparateRange = 5;
    public float AvoidRange = 5;
    Boid[] objects;
    Avoid[] objectsToAvoid;    
    public float AlignmentSmoothVal = .01f;
    public int TickRate;
    public GameObject FollowObject; 
    public bool isFrozen = true;
    int frames = 1;
    public int AmmountOfBoids;

    // Start is called before the first frame update
    void Start()
    {      
        objects = FindObjectsOfType<Boid>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (frames % (TickRate + 1) == 0 && isFrozen == false)
        {
            objects = FindObjectsOfType<Boid>();
            objectsToAvoid = FindObjectsOfType<Avoid>();
            AmmountOfBoids = objects.Length;
            if (FollowObject == null)
            {
                Movement FollowObjectScript = FindObjectOfType<Movement>();
                if (FollowObjectScript != null)
                {
                    FollowObject = FollowObjectScript.gameObject;
                }
            }
            for (int i = 0; i < objects.Length; i++)
            {
                Rigidbody2D rb = objects[i].GetComponent<Rigidbody2D>();
                rb.AddRelativeForce(Vector2.up * 150);
                Vector3 CohesionVector = Cohesion(objects[i].gameObject);
                Vector3 SeparationVector = Separation(objects[i].gameObject);
                Vector3 AlignmentVector = Alignment(objects[i].gameObject);
                Vector3 AvoidanceVector = Avoidance(objects[i].gameObject);
                SetDirectionOfBoid(CohesionVector, AlignmentVector, SeparationVector, AvoidanceVector, objects[i].gameObject);

            }
            frames = 1;
        }
        else
            frames++;

    }

    public void UnfreezeBoids()
    {
        if (isFrozen == true)
        {
            objects = FindObjectsOfType<Boid>();
            for (int i = 0; i < objects.Length; i++)
            {
                Rigidbody2D rb = objects[i].GetComponent<Rigidbody2D>();
                rb.AddRelativeForce(Vector2.up * 150);
            }
            isFrozen = false;
        }
    }
    public void FreezeBoids()
    {
        if (isFrozen == false)
        {            
            isFrozen = true;
        }
    }
    Vector3 Cohesion(GameObject boid)
    {
        int count = 0;
        Vector3 AveragePos = new Vector3(0,0,0);
        Vector3 CoheasionVector;
        for (int i = 0; i < objects.Length; i++)
        {
            if (Vector2.Distance(objects[i].gameObject.transform.position, boid.transform.position) < FriendRange && boid.transform.position != objects[i].gameObject.transform.position)
            {
                AveragePos += objects[i].gameObject.transform.position;
                count += 1;                
            }
        }
        if (count != 0)
        {
            CoheasionVector = (AveragePos / count) - boid.transform.position;
        }
        else
        {
            CoheasionVector = new Vector3(0, 0, 0);
        }
        return CoheasionVector;
    }

    Vector3 Separation(GameObject boid)
    {        
        Vector3 SeparatePos = new Vector3(0, 0, 0);
        for (int i = 0; i < objects.Length; i++)
        {
            if (Vector2.Distance(objects[i].gameObject.transform.position, boid.transform.position) < SeparateRange && boid.transform.position != objects[i].gameObject.transform.position)
            {
                SeparatePos += (boid.transform.position - objects[i].gameObject.transform.position) / (boid.transform.position - objects[i].gameObject.transform.position).magnitude;                
            }
        }
        return SeparatePos;
    }

    Vector3 Alignment(GameObject boid)
    {
        int count = 0;
        Vector2 AverageDir = new Vector2(0,0);
        for (int i = 0; i < objects.Length; i++)
        {
            if (Vector2.Distance(objects[i].gameObject.transform.position, boid.transform.position) < FriendRange && boid.transform.position != objects[i].gameObject.transform.position)
            {
                Rigidbody2D rb = objects[i].GetComponent<Rigidbody2D>();
                AverageDir += rb.velocity.normalized;
                count += 1;                
            }
        }
        if (count != 0)
        {
            AverageDir = AverageDir / count;
        }      
        Rigidbody2D rbthis = boid.GetComponent<Rigidbody2D>();
        Vector3 AlignmentVector = AverageDir - rbthis.velocity;
        return AlignmentVector;      
    }

    Vector3 Avoidance(GameObject boid)
    {
        Vector3 AvoidanceVector = new Vector3(0, 0, 0);
        for (int i = 0; i < objectsToAvoid.Length; i++)
        {
            if (Vector2.Distance(objectsToAvoid[i].gameObject.transform.position, boid.transform.position) < AvoidRange && boid.transform.position != objectsToAvoid[i].gameObject.transform.position)
            {
                AvoidanceVector += (boid.transform.position - objectsToAvoid[i].gameObject.transform.position) / (boid.transform.position - objectsToAvoid[i].gameObject.transform.position).magnitude;
            }
        }
        return AvoidanceVector;
    }

    void SetDirectionOfBoid(Vector3 Cohesion, Vector3 Alignment, Vector3 Separation, Vector3 Avoidance, GameObject boid)
    {
        Rigidbody2D rb = boid.GetComponent<Rigidbody2D>();
        Boid boidScript = boid.GetComponent<Boid>();      
        Vector3 followVector;
        if (FollowObject != null)
        {
            followVector = FollowObject.transform.position - boid.transform.position;
        }
        else
            followVector = new Vector3(0, 0, 0);
        Vector3 BoidVelocity = (boidScript.PreviousBoidSpeed * PreviousSpeedWeight) + (Cohesion * CohesionWeight) + (Alignment * AlignmentWeight) + (Separation * SeparationWeight) + (followVector.normalized * FollowWeight) + (Avoidance * AvoidanceWeight);
        float speed = rb.velocity.magnitude;
        Vector2 LerpedVelocity = Vector2.Lerp(rb.velocity.normalized, BoidVelocity, AlignmentSmoothVal) * speed;
        if (LerpedVelocity.magnitude > maxSpeed)
        {
            LerpedVelocity = (LerpedVelocity / LerpedVelocity.magnitude) * maxSpeed;            
        }
        if (LerpedVelocity.magnitude < minSpeed && LerpedVelocity.magnitude != 0)
        {
            LerpedVelocity = (LerpedVelocity / LerpedVelocity.magnitude) * minSpeed;
        }
        //rb.velocity = BoidVelocity;    
        rb.velocity = LerpedVelocity;
        float degToRot = Mathf.Atan2(rb.velocity.y, rb.velocity.x);
        degToRot = degToRot * Mathf.Rad2Deg - 90;
        boid.transform.eulerAngles = new Vector3(0, 0, degToRot);
        boidScript.PreviousBoidSpeed = LerpedVelocity;
       // boidScript.PreviousBoidSpeed = rb.velocity.normalized;        
    }


}
