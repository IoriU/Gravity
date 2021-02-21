using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableArea : MonoBehaviour
{
    [SerializeField] private bool isClickable;
    [SerializeField] private Material[] materials;
    [SerializeField] private Renderer rend;
    
    // Start is called before the first frame update
    void Start()
    {
        rend.enabled = false;       
    }

    public void ToogleArea()
    {

        isClickable = !isClickable;
        rend.sharedMaterial = materials[0];

    }

    private void OnEnable()
    {
        if (GameSystem.clickableAreas == null)
            GameSystem.clickableAreas = new List<ClickableArea>();

        GameSystem.clickableAreas.Add(this);
    }

    public bool GetClickable()
    {
        return isClickable;
    }

    public void OnSelected()
    {
        if (isClickable)
        {
            rend.sharedMaterial = materials[0];
        }
        else
        {
            rend.sharedMaterial = materials[1];
        }
        rend.enabled = true;
    }

    public void ResetRenderer()
    {
        rend.enabled = false;
    }

    private void OnDestroy()
    {
        GameSystem.clickableAreas.Remove(this);
    }
}
