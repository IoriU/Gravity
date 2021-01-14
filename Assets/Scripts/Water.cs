using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private Rigidbody rbBall;
    private MeshRenderer waterMesh;
    private MeshRenderer ballMesh;
    public float konst;

    private void Start()
    {
        waterMesh = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.gameObject.CompareTag("Ball"))
        {
            rbBall = other.GetComponent<Rigidbody>();
            ballMesh = other.GetComponent<MeshRenderer>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.transform.gameObject.CompareTag("Ball"))
        {
            float multiplier = (waterMesh.bounds.max.y - ballMesh.bounds.center.y)/(waterMesh.bounds.max.y - waterMesh.bounds.min.y);
            Vector3 force = new Vector3(0f, 1f, 0f).normalized * konst * multiplier;
            rbBall.AddForce(force);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Ball"))
        {
            rbBall = null;
        }
    }
}
