using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private UISystem uiSystem;
    [SerializeField] private Vector3 transPos;
    private Quaternion transRot;
    public Rigidbody rb;

    
    private void Start()
    {
        transPos = transform.position;
        transRot = transform.rotation;
        uiSystem = GameObject.Find("UIController").GetComponent<UISystem>();
    }

    void OnEnable()
    {
        if (GameSystem.Balls == null)
            GameSystem.Balls = new List<Ball>();

        GameSystem.Balls.Add(this);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("Enemy"))
        {
            transform.position = transPos;
            transform.rotation = transRot;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (collision.transform.CompareTag("Respawn"))
        {
            transPos = collision.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            uiSystem.WinGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Respawn"))
        {
            transPos = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            uiSystem.RestartTimer();
        }
    }


    void OnDisable()
    {
        GameSystem.Balls.Remove(this);
    }
}
