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

    [SerializeField] GameObject _gamewin;

    public bool _checkMessage = false;

    public bool _checkMap = false;
    void Awake()
    {
        _gameover.SetActive(false);
        _message.SetActive(false);
        _map.SetActive(false);
        _EToInteract.SetActive(false);
        _checkMessage = false;
        _checkMap = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _checkMap == true)
        {
            _map.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && Locator.Instance._clicked._itemDetected == true)
        {
            _EToInteract.SetActive(false);
            Locator.Instance._clicked._itemDetected = false;
        }
    }
    public void GameOver()
    {
        //Time.timeScale = 0f;
        _gameover.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Game Over");
    }

    public void GameWin()
    {
        //Time.timeScale = 0f;
        _gamewin.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Game Win");
    }

    public void MapDisplay()
    {
        _map.SetActive(true);
        _checkMap = true;
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
