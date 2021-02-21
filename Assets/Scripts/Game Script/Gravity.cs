using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gravity : MonoBehaviour
{
    protected const float G = 6.674f;
    [SerializeField] protected bool isDefault;
    [SerializeField] private LayerMask layerMask;

    public Rigidbody rb;

    void FixedUpdate()
    {
        foreach (Ball ball in GameSystem.Balls)
        {
            if (ball != this)
                DoPhysics(ball);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.transform.gameObject.name);
        if (!collision.transform.CompareTag("Clickable"))
        {
            if (!(collision.transform.CompareTag("Ball") || collision.transform.CompareTag("Gravity")))
            {
                GameObject.FindGameObjectWithTag("UIController").GetComponent<UISystem>().ReduceItem();
            }
            Destroy(this.gameObject);
        }
        
    }


    public bool CheckHit(Ball ball, Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, direction, out hit, Vector3.Distance(this.transform.position,
            ball.transform.position), layerMask))
        {
            Debug.DrawLine(this.transform.position, direction);
            if (hit.transform.tag == "Ball")
            {
                return true;
            }
        }
        return false;
    }

    public void DoPhysics(Ball ball)
    {
        Rigidbody ballAffected = ball.rb;

        Vector3 direction = ballAffected.position - rb.position;

        if (CheckHit(ball, direction))
        {
            float distance = direction.magnitude;

            if (distance == 0f)
            {
                return;
            }

            float forceMagnitude = G * (rb.mass * ballAffected.mass) / Mathf.Pow(distance, 2);
            Vector3 force = (-1 * direction.normalized) * forceMagnitude;

            ballAffected.AddForce(Calculate(direction.normalized, forceMagnitude));
        }
    }

    public abstract Vector3 Calculate(Vector3 direction, float force);
    
}