using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Locator : MonoBehaviour
{
    public static Locator Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy (this);
            return;
        }

        Instance = this;   
    }

    public Player _player;
    public Items _items;
    public NPC _NPC;
    public ClickRaycast _clicked;
    
}
