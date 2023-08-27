using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour, ITick
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip[] clips;

    private int chosenIndex;
    private bool canRunIE;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoopTimer());
    }

    private void Update()
    {
        if (canRunIE)
        {
            StartCoroutine(LoopTimer());
        }
    }

    private IEnumerator LoopTimer()
    {
        canRunIE = false;

        source.clip = clips[chosenIndex];
        source.Play();

        yield return new WaitForSeconds(clips[chosenIndex].length);
        
        canRunIE = true;
    }

    public void StopIEnum()
    {
        StopCoroutine(LoopTimer());
        canRunIE = true;
    }

    public void CallTicker()
    {

    }
}
