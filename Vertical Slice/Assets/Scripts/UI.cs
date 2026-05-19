using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    
    [SerializeField] GameObject _gameover;

    [SerializeField] GameObject _map;

    [SerializeField] GameObject _message;

    [SerializeField] GameObject _glitch;

    [SerializeField] public GameObject _EToInteract;

    [SerializeField] GameObject _gamewin;

    [SerializeField] GameObject _empty;

    [SerializeField] GameObject _staminaBar;

    [SerializeField] GameObject _crosshair;
    public bool _checkMessage = false;

    public bool _checkMap = false;

    public bool _checkGlitch = false;
    void Awake()
    {
        _gameover.SetActive(false);
        _message.SetActive(false);
        _map.SetActive(false);
        _EToInteract.SetActive(false);
        _empty.SetActive(false);
        _staminaBar.SetActive(false);
        _crosshair.SetActive(false);
        _checkMessage = false;
        _checkMap = false;
        _checkGlitch = false;
        
    }

    public void ShowEmptyDisplay()
    {
        StartCoroutine(EmptyDisplay());
    }

    public void ShowGlitchDisplay()
    {
        StartCoroutine(GlitchDisplay());
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _checkMap == true)
        {
            _map.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q) && _checkGlitch == true)
        {
            _glitch.SetActive(false);
        }

        /*if (Input.GetKeyDown(KeyCode.E) && Locator.Instance._clicked._itemDetected == true)
        {
            _EToInteract.SetActive(false);
            Locator.Instance._clicked._itemDetected = false;
        }*/
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
        Time.timeScale = 0f;
        _gamewin.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Game Win");
    }

    public void MapDisplay()
    {
        /*if (Locator.Instance._cassette._isTrueCassette == true)
        {
        }*/

        _map.SetActive(true);
        _checkMap = true;
    }

    public IEnumerator EmptyDisplay()
    {
        _empty.SetActive(true);
        yield return new WaitForSeconds (1.5f);
        _empty.SetActive(false);
    }

    public IEnumerator GlitchDisplay()
    {
        /*if (Locator.Instance._cassette._isTrueCassette == true)
        {
        }*/

        _glitch.SetActive(true);
        _checkGlitch = true;
        yield return new WaitForSeconds (1.5f);
        _glitch.SetActive(false);
        
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
