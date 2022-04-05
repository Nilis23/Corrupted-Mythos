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
        pause.SetActive(false);

        Invoke("unpause", 0.2f);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        
        GameObject.FindObjectOfType<PlayerHealth>()?.RespawnPlayer();

        if (pause.activeSelf)
        {
            pause.SetActive(false);
        }

        Invoke("unpause", 0.2f);
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

    void unpause()
    {
        player.paused = false;
    }
}
