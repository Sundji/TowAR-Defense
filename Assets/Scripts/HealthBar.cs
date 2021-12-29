using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image filler;

    public void SetHealth(int health) 
    {
        filler.fillAmount = health / 100.0f;
    }
}
