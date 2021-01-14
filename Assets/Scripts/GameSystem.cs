using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChoiceState { IDLE, CHOICE }

public class GameSystem : MonoBehaviour
{


    public static List<Ball> Balls;
    [SerializeField] private GameObject pusher;
    [SerializeField] private GameObject puller;
    [SerializeField] private GameObject selected;
    

    [SerializeField] private ClickableArea clickableArea;
    public static List<ClickableArea> clickableAreas;

    [SerializeField] private UISystem uiSystem;

    private Vector3 mousePos;
    private Vector3 objectPos;
    [SerializeField] private Camera cam;


    void Update()
    {
        if (Input.GetButtonDown("Fire1") && selected != null)
        {
            AddGravity(Input.mousePosition);
        }
        
    }

    private void AddGravity(Vector3 mousePos)
    {
        objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        objectPos.z = 0f;

        if (CheckClickable(objectPos))
        {
            uiSystem.AddItem();
            Instantiate(selected, objectPos, Quaternion.identity);
        }
    }

    private bool CheckClickable(Vector3 mousePos)
    {
        RaycastHit hit;
        mousePos.z = 0;
        Vector3 direction = mousePos - cam.transform.position;
        if (Physics.Raycast(cam.transform.position, direction, out hit))
        {
            Debug.DrawLine(cam.transform.position, direction);
            if (hit.transform.tag.Equals("Clickable") && hit.transform.GetComponent<ClickableArea>().GetClickable())
            {
                return true;
            }
        }
        return false;

    }

    public GameObject GetSelected()
    {
        return selected;
    }

    public void OnPusherButton()
    {
        if (selected != pusher)
        {
            selected = pusher;
            foreach (ClickableArea click in clickableAreas)
            {
                click.OnSelected();
            }
            
        }
        else
        {
            selected = null;
            foreach (ClickableArea click in clickableAreas)
            {
                click.ResetRenderer();
            }
        }

    }

    public void OnPullerButton()
    {
        if (selected != puller)
        {
            selected = puller;
            foreach (ClickableArea click in clickableAreas)
            {
                click.OnSelected();
            }
        }
        else
        {
            selected = null;
            foreach (ClickableArea click in clickableAreas)
            {
                click.ResetRenderer();
            }
        }
    }

    
}


