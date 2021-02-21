using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public enum ChoiceState { IDLE, CHOICE }

public class GameSystem : MonoBehaviour
{


    public static List<Ball> Balls;
    [SerializeField] private GameObject pusher;
    [SerializeField] private GameObject pusherButton;
    [SerializeField] private GameObject puller;
    [SerializeField] private GameObject pullerButton;
    [SerializeField] private GameObject selected;
    

    public static List<ClickableArea> clickableAreas;

    [SerializeField] private UISystem uiSystem;

    private Vector3 objectPos;
    [SerializeField] private Camera cam;

    [SerializeField] private bool isPaused;
    [SerializeField] private bool isWin;
    [SerializeField] private GameObject pausePrefab;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject MainUI;
    private void Start()
    {
        isPaused = false;
        isWin = false;
        Time.timeScale = 1f;
    }

    
    void Update()
    {
        if (!(isPaused || isWin))
        {
            if (Input.GetButtonDown("Fire1") && selected != null)
            {
                AddGravity(Input.mousePosition);
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                OnPusherButton();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                OnPullerButton();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();    
        }
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && !isWin)
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }

        }

    }


    private void Pause()
    {
        pauseUI = Instantiate(pausePrefab);
        isPaused = true;
        Time.timeScale = 0f;
        MainUI.SetActive(false);

    }

    public void Resume()
    {
        Destroy(pauseUI);
        isPaused = false;
        Time.timeScale = 1f;
        MainUI.SetActive(true);
    }

    public void win(int star, int itemCount)
    {
        
        isWin = true;
        int level = int.Parse(SceneManager.GetActiveScene().name.Substring(6));
        SaveLoad.SaveSystem(level, star, itemCount, 1);
    }


    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            pusherButton.GetComponent<Image>().color = Color.green;
            pullerButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            selected = pusher;
            foreach (ClickableArea click in clickableAreas)
            {
                click.OnSelected();
            }
            
        }
        else
        {
            selected = null;
            pusherButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
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
            pullerButton.GetComponent<Image>().color = Color.green;
            pusherButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            foreach (ClickableArea click in clickableAreas)
            {
                click.OnSelected();
            }
        }
        else
        {
            selected = null;
            pullerButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            foreach (ClickableArea click in clickableAreas)
            {
                click.ResetRenderer();
            }
        }
    }

    
}


