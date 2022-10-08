using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private ActivePlayer playerOne;
    [SerializeField] private ActivePlayer playerTwo;
    [SerializeField] private float maxTime;
    [SerializeField] private Image timer;
    [SerializeField] private float timeBetweenTurns;
    [SerializeField] private TextMeshProUGUI seconds;
    public GameObject P1Cam;
    public GameObject P2Cam;

    private ActivePlayer currentPlayer;
    private float currentTurnTime;
    private float currentDelay;

    private void Start()
    {
        playerOne.AssignManager(this);
        playerTwo.AssignManager(this);
        currentPlayer = playerOne;

    }

    private void Update()
    {
        if (currentDelay <= 0)
        {
            currentTurnTime += Time.deltaTime;
            if (currentTurnTime >= maxTime)
            {
                ChangeTurn();
                ResetTimer();
            }
            UpdateTimeVisual();

        }
        else
        {
            currentDelay -= Time.deltaTime;
        }
    }

    public bool PlayerCanPlay()
    {
        return currentDelay <= 0;
    }
    public ActivePlayer GetCurrentPlayer()
    {
        return currentPlayer;
    }
    public void ChangeTurn()
    {
        if(playerOne == currentPlayer)
        {
            currentPlayer = playerTwo;
            P2Cam.SetActive(true);
            P1Cam.SetActive(false);
        }
        else if(playerTwo == currentPlayer)
        {
            currentPlayer = playerOne;
            P1Cam.SetActive(true);
            P2Cam.SetActive(false);
        }
        ResetTimer();
        UpdateTimeVisual();
    }
    private void ResetTimer()
    {
        currentTurnTime = 0;
        currentDelay = timeBetweenTurns;
    }
    private void UpdateTimeVisual()
    {
        timer.fillAmount = 1 - (currentTurnTime / maxTime);
        seconds.text = Mathf.RoundToInt(maxTime - currentTurnTime).ToString();

    }
}
