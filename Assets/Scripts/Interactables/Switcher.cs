using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : Interactable
{
    [SerializeField] private Sprite inactiveSprite;
    [SerializeField] private Sprite activeSprite;
    [SerializeField] private MovingPlatform platform;

    private SpriteRenderer switcherSprite;
    private bool isActive;

    private void Start()
    {
        switcherSprite = GetComponentInChildren<SpriteRenderer>();
    }
    public override void Interact()
    {
        platform.Activate();
        isActive = !isActive;
        if (isActive) switcherSprite.sprite = activeSprite;
        else if (!isActive) switcherSprite.sprite = inactiveSprite;
    }
}
