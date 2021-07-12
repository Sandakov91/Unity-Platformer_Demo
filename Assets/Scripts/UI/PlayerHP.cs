using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite heartFull;
    [SerializeField] private Sprite heartEmpty;

    public void RefreshHPView()
    {
        if(player.health == 3)
        {
            foreach (Image heart in hearts)
            {
                heart.sprite = heartFull;
            }
        }
        else if(player.health == 2)
        {
            hearts[0].sprite = heartEmpty;
            hearts[1].sprite = heartFull;
            hearts[2].sprite = heartFull;
        }
        else if (player.health == 1)
        {
            hearts[0].sprite = heartEmpty;
            hearts[1].sprite = heartEmpty;
            hearts[2].sprite = heartFull;
        }
        else
        {
            foreach (Image heart in hearts)
            {
                heart.sprite = heartEmpty;
            }
        }
    }
}
