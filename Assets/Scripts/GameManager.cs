using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] MenuChanger changerScript;
    [SerializeField] SpinManager spinManagerScript;
    [SerializeField] AudioManager audioManagerScript;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void TickMenuChanger()
    {
        changerScript.CallTicker();
        spinManagerScript.CallTicker();
        audioManagerScript.CallTicker();
    }
}
