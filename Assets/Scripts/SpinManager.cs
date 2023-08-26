using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinManager : MonoBehaviour, ITick
{
    [SerializeField] SpinObject spinObjectScript;
    [SerializeField] GameObject spinningObject;
    [SerializeField, Range(15f, 240f)] float spinningSpeed;
    [SerializeField, Range(0.5f, 3f)] float waitToRotateMinimum;
    [SerializeField, Range(3f, 5f)] float waitToRotateMaximum;
    
    private bool isEscaped = false;

    private void Start()
    {
        SetStartingValues();
    }
    
    /// <summary>
    /// Call the Tick() funciton.
    /// </summary>
    public void CallTicker()
    {
        Tick();
    }

    /// <summary>
    /// Tick the object.
    /// </summary>
    private void Tick()
    {
        spinObjectScript.SetCanSpin(!isEscaped);
        isEscaped = !isEscaped;
    
    }

    /// <summary>
    /// Set the starting values for different variables.
    /// </summary>
    private void SetStartingValues()
    {
        spinObjectScript.SetRotSpeed(spinningSpeed);
        spinObjectScript.SetWaitMax(waitToRotateMaximum);
        spinObjectScript.SetWaitMin(waitToRotateMinimum);
        Tick();
    }
}
