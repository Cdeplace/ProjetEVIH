using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _MainMenu : MonoBehaviour
{

    public GameObject Menu;


    void Start()
    {
        Time.timeScale = 1;
        Menu.SetActive(false);
     
    }

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                Pause();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                HidePause();
            }
        }
    }

    public void Pause()
    {
        Menu.SetActive(true);

    }

    public void HidePause()
    {
        Menu.SetActive(false);
    }

    public void Reload()
    {

        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }





}