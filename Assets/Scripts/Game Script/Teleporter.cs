using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private bool isWarped;
    [SerializeField] private GameObject inWarp;
    [SerializeField] private Teleporter outWarp;
    [SerializeField] private Color color;

    private void Start()
    {
        GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
        inWarp.GetComponent<Renderer>().material.SetColor("_EmissionColor", outWarp.GetColor());
    }

    public Color GetColor()
    {
        return this.color;
    }

    private void FixedUpdate()
    {
        inWarp.gameObject.transform.Rotate(new Vector3(0f, 0f, -1f));
    }

    public bool GetIsWarped()
    {
        return isWarped;
    }

    public void SetIsWarped(bool value)
    {
        this.isWarped = value;
    }

    /// <summary>
    /// teleport object and disable exit teleport
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (!isWarped && other.transform.CompareTag("Ball"))
        {
            other.transform.position = outWarp.transform.position;
            outWarp.SetIsWarped(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isWarped = false;
    }

}
