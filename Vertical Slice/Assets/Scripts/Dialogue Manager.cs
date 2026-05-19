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

    private int _index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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
        _playerDialogue.SetActive(false);
        
    }
    void NextLine()
    {
        if(_currentLine < _scriptableObj._lines.Length)
        {
            // if we still have NPC lines left, keep playing NPC lines
            ShowLines(_currentNode._lines[_currentLine]);
            _currentLine++;
        }
        else 
        {
            // if there are no NPC or player lines left, close dialogue UI
            EndDialogue();
        }
    }
}
