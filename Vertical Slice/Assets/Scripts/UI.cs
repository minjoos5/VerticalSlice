using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    
    [SerializeField] GameObject _gameover;

    [SerializeField] GameObject _map;

    [SerializeField] GameObject _message;

    [SerializeField] public GameObject _EToInteract;

    public bool _checkMessage = false;
    void Awake()
    {
        _gameover.SetActive(false);
        _message.SetActive(false);
        _map.SetActive(false);
        _EToInteract.SetActive(false);
        _checkMessage = false;
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        _gameover.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Game Over");
    }

    public void MapDisplay()
    {
        _map.SetActive(true);
    }

    public void MessageDisplay()
    {
        _message.SetActive(true);
        _checkMessage = true;
    }

    public void EInteractDisplay()
    {
        _EToInteract.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
