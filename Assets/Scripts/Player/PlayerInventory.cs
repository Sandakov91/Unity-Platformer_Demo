using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private KeysUI keysUI;
    public bool hasKey { get; private set; }

    private void Start()
    {
        hasKey = false;
    }
    public void AddKey()
    {
        hasKey = true;
        keysUI.AddKey();
    }
}
