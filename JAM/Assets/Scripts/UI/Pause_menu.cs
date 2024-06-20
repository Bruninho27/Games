using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause_menu : MonoBehaviour
{
    [SerializeField] GameObject Pausemenu;

    public void Pause()
    {
        Pausemenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Pausemenu.SetActive(false);
        Time.timeScale = 1;
    }

}
