using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinManager : MonoBehaviour, ITick
{
    [SerializeField] SpinObject spinObjectScript;
    [SerializeField] RatSpinning ratSpinScript;
    [SerializeField] GameObject spinningObject;
    [SerializeField] Toggle spinScriptToggle;
    [SerializeField, Range(15f, 240f)] float spinningSpeed;
    [SerializeField, Range(0.5f, 3f)] float waitToRotateMinimum;
    [SerializeField, Range(3f, 5f)] float waitToRotateMaximum;
    
    private bool isEscaped = false;

    private void Start()
    {
        SetStartingValues();
        spinScriptToggle.onValueChanged.AddListener(SetSpinScript);
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
        ratSpinScript.SetRatCanSpin(!isEscaped);
        isEscaped = !isEscaped;
    }

    /// <summary>
    /// Set the starting values for different variables.
    /// </summary>
    private void SetStartingValues()
    {
        ratSpinScript.SetRatRotSpeed(spinningSpeed);
        ratSpinScript.SetRatWaitMax(waitToRotateMaximum);
        ratSpinScript.SetRatWaitMin(waitToRotateMinimum);

        Tick();
    }

    private void SetSpinScript(bool val)
    {
        spinObjectScript.enabled = val;
        ratSpinScript.enabled = val;
    }
}
