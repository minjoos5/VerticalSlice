using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] private TMP_Text _playerText;
    [SerializeField] private GameObject _playerDialogue;
    [SerializeField] private Monologue _scriptableObj;

    [SerializeField] private Monologue _scriptableObjL2;

    [SerializeField] public GameObject _npcObj;

    [SerializeField] public GameObject _npcL2Obj;

    [SerializeField] public GameObject _playerObj;

    [SerializeField] public GameObject _introCam;

    private int _currentLine = 0;

    private int _currentLineL2 = 0;

    private Monologue _currentNode;

    public bool _gameStart;

    public bool _l2Start = false;

    // Start is called before the first frame update
    void Awake()
    {
        _currentLine = 0;
        _currentLineL2 = 0;
        _gameStart = false;
        _playerObj.SetActive(false);
        _introCam.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("dialogue l2start is " + _l2Start);
        if (_l2Start == true)
        {
            gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _gameStart == false)
        {
            NextLine();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _gameStart == true)
        {
            NextLineL2();
        }

        if (Input.GetKeyDown(KeyCode.X) && _gameStart == false)
        {
            EndDialogue();
        }
        else if (Input.GetKeyDown(KeyCode.X) && _gameStart == true)
        {
            EndDialogueL2();
        }
    }

    public void ShowLines(string dialogue)
    {
        gameObject.SetActive(true);
        _playerText.text = dialogue;
    }

    private void EndDialogue ()
    {
        _currentLine = 0;
        _gameStart = true;
        gameObject.SetActive(false);
        //Debug.Log(_gameStart);
        _npcObj.SetActive(true);
        _playerObj.SetActive(true);
        _introCam.SetActive(false);
    }

    private void EndDialogueL2()
    {
        _currentLineL2 = 0;
        gameObject.SetActive(false);
        _npcL2Obj.SetActive(true);
    }
    void NextLine()
    {
        if(_currentLine < _scriptableObj._lines.Length)
        {
            // if we still have NPC lines left, keep playing NPC lines
            ShowLines(_scriptableObj._lines[_currentLine]);
            _currentLine++;
        }
        else 
        {
            // if there are no NPC or player lines left, close dialogue UI
            EndDialogue();
        }
    }

    void NextLineL2()
    {
        if(_currentLineL2 < _scriptableObjL2._lines.Length)
        {
            // if we still have NPC lines left, keep playing NPC lines
            ShowLines(_scriptableObjL2._lines[_currentLineL2]);
            _currentLineL2++;
        }
        else 
        {
            // if there are no NPC or player lines left, close dialogue UI
            EndDialogueL2();
        }
    }
}
