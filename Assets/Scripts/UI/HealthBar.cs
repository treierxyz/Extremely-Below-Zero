using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text healthDisplay;
    public Slider slider;
    public GameObject healthBar;
    public GameObject character;
    private PlayerManger playerManger;
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
        playerManger = character.GetComponent<PlayerManger>();
        CurrentValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentValue = playerManger.health/playerManger.healthStart;
        healthDisplay.text = (playerManger.health).ToString();
    }
}
