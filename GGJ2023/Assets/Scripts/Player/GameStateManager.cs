using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStateManager : MonoBehaviour
{

    // Matt Thompson
    // Last Modified 2/4/23

    // A script for for managing various values for the game state such as hunger, if the player has been caught, if the game is over, etc.

    [SerializeField] public bool playerCaught;
    [SerializeField] public bool gameOver;

    // values for hunger bar, in this case 100% means the player is "full" and 0% means they are too hungry and have lost the game
    [SerializeField] public float maxHunger = 100.0f;
    [SerializeField] public float minHunger = 0.0f;
    [SerializeField] public float currentHunger = 50.0f;

    // if a player eats a root, increase their hunger/life by this amount
    [SerializeField] public float rootHungerValue = 10.0f;

    // how much hunger changes over time and how frequently it changes respectively
    [SerializeField] public float hungerChangeInrement = 1.0f;
    [SerializeField] public float hungerTimeIncrement = 1.0f;

    [SerializeField] public TMP_Text timer;
    private float timerValue;
    private float minutes;
    private float seconds;

    [SerializeField] public Slider healthBarSlider;

    void Start()
    {
        // kick of the coroutine for changing hunger over time
        StartCoroutine("HungerTimer");
    }

    // Update is called once per frame
    void Update()
    {
        // if the player reaches the minimum hunger or is caught by an enemy, signify the game is over
        if ((currentHunger <= minHunger || playerCaught) && gameOver == false) 
        {
            gameOver = true;
            StopCoroutine("HungerTimer");
        }

        // if the game is not over, increment timers in 00:00 format
        if (gameOver == false)
        {
            timerValue += Time.deltaTime;

            minutes = Mathf.FloorToInt(timerValue / 60);
            seconds = Mathf.FloorToInt(timerValue % 60);

            timer.text = "Timer: " + minutes.ToString("00") + ":" + seconds.ToString("00");
        }

        // update health bar
        healthBarSlider.value = currentHunger / maxHunger;

        // if (Input.GetKeyDown(KeyCode.Space)) IncreaseByRootValue();
    }

    // change hunger over time, trending towards 0/empty
    IEnumerator HungerTimer()
    {
        for (; ; )
        {
            if (currentHunger - hungerChangeInrement < minHunger) { currentHunger = minHunger; }
            else { currentHunger -= hungerChangeInrement; }

            yield return new WaitForSeconds(hungerTimeIncrement);
        }
    }

    // if the player eats a root, increase their hunger by a set amount and ceiling their current number at the max hunger
    void IncreaseByRootValue()
    {
        if (currentHunger + rootHungerValue > maxHunger) { currentHunger = maxHunger; }
        else { currentHunger += rootHungerValue; }
    }

}
