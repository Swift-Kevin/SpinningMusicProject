using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour, ITick
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioMixer volumeMixer;
    [SerializeField] float rateToMuffle;

    private bool runMuffler;
    private bool runUnMuffler;
    private float muffleCurrent;
    private float muffleAmount;
    private bool tickBool;

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
        float a = 0;
        volumeMixer.GetFloat("Vol", out a);
        volumeSlider.value = a;
    }

    private void Update()
    {

        if (runMuffler)
        {
            volumeMixer.GetFloat("Muffler", out muffleCurrent);
            muffleAmount = Mathf.Lerp(muffleCurrent, 500f, Time.deltaTime * rateToMuffle);
            volumeMixer.SetFloat("Muffler", muffleAmount);
            if (muffleAmount <= 500f)
                runMuffler = false;
        }
        else if (runUnMuffler)
        {
            volumeMixer.GetFloat("Muffler", out muffleCurrent);
            muffleAmount = Mathf.Lerp(muffleCurrent, 7500f, Time.deltaTime * rateToMuffle);
            volumeMixer.SetFloat("Muffler", muffleAmount);
            if (muffleAmount >= 7500f)
                runUnMuffler = false;
        }
    }

    public void Muffle()
    {
        runMuffler = true;
        runUnMuffler = false;
    }

    public void Unmuffle()
    {
        runMuffler = false;
        runUnMuffler = true;
    }

    private void Tick()
    {
        tickBool = !tickBool;
        if (tickBool)
            Muffle();
        else
            Unmuffle();
    }

    public void CallTicker()
    {
        Tick();
    }
    private void SetVolume(float val) { volumeMixer.SetFloat("Vol", Mathf.Log10(val) * 20f); }
}
