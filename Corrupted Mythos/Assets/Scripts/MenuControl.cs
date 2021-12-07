using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject pause;
    public GameObject restart;
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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameObject.FindObjectOfType<PlayerHealth>()?.RespawnPlayer();
    }
    public void Quit()
    {
        Time.timeScale = 1f;
        player.paused = false;
        SceneManager.LoadScene(0);
    }
}
