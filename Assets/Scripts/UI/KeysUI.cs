using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeysUI : MonoBehaviour
{
    [SerializeField] private Sprite keyEmpty;
    [SerializeField] private Sprite keyFull;
    [SerializeField] private Image keyImage;

    private void Start()
    {
        keyImage.sprite = keyEmpty;
    }
    public void AddKey()
    {
        keyImage.sprite = keyFull;
    }
}
