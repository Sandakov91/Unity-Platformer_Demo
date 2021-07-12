using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    private Slider slider;
    private float maxHP;
    void Start()
    {
        slider = GetComponent<Slider>();
        maxHP = enemy.HP;
    }
    public void RefreshView()
    {
        slider.value = enemy.HP / maxHP;
    }
}
