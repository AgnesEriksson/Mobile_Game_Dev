using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Advertisements.Advertisement;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource pop;
    [SerializeField]
    private AudioSource scramble;
    [SerializeField]
    private AudioSource rock;
    [SerializeField]
    private AudioSource bg;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            return;
        }
        Instance = this;
    }

    public void Start()
    {
        PlayBG();
    }
    public void PlayPop()
    {
        pop.PlayOneShot(pop.clip);
    }

    public void PlayScramble()
    {
        scramble.PlayOneShot(scramble.clip);
    }

    public void PlayRock()
    {
        StartCoroutine("Delay");
        rock.Play();
    }

    public void StopRock()
    {
        rock.Stop();
    }

    public void PlayBG()
    {
        bg.Play();
    }

    public void StopBG()
    {
        bg.Stop();
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.4f);
    }
}
