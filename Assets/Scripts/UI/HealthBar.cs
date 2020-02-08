using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthDisplay;
    public Slider slider;
    public GameObject healthBar;
    public GameObject character;
    private PlayerManager playerManager;
    private float currentValue = 0f;
    public float CurrentValue {
    get {
        return currentValue;
    }
    set {
        currentValue = value;
        slider.value = currentValue;
    }
}
    // Start is called before the first frame update
    void Start()
    {
        playerManager = character.GetComponent<PlayerManager>();
        CurrentValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentValue = playerManager.health/playerManager.healthStart;
        healthDisplay.text = (playerManager.health).ToString();
    }
}
