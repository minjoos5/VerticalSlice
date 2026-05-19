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

    private int _currentLine = 0;

    private Monologue _currentNode;

    public bool _gameStart;

    // Start is called before the first frame update
    void Awake()
    {
        _currentLine = 0;
        _gameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
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
}
