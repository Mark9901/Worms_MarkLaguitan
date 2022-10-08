using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWhoWin : MonoBehaviour
{
    public Image P1Won;
    public Image P2Won;
    PlayerManager manager;

    public void AssignManager(PlayerManager theManager)
    {
        manager = theManager;
    }

    public void WhoWins()
    {
        
    }
}
