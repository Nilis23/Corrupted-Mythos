using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject pause;
    public GameObject restart;
    public GameObject reload;
    public PlayerMovement player;

    public void Resume()
    {
        Time.timeScale = 1f;
        player.paused = false;
        pause.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        player.paused = false;
        GameObject.FindObjectOfType<PlayerHealth>()?.RespawnPlayer();

        if (pause.activeSelf)
        {
            pause.SetActive(false);
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (reload.activeSelf)
        {
            reload.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        player.paused = false;
        SceneManager.LoadScene(0);
    }
}
