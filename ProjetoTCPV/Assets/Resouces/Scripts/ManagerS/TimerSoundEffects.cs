using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSoundEffects : MonoBehaviour
{
    [SerializeField]AudioSource compassSFX, correctSFX, wrongSFX;

    public void PlayCompass(float delay)
    {
        compassSFX.PlayDelayed(delay);
    }
    public void PlayCorrect()
    {
        correctSFX.Play();
    }
    public void PlayWrong()
    {
        wrongSFX.Play();
    }

    public bool IsCorrectPlaying()
    {
        return correctSFX.isPlaying;
    }

    public bool IsWrongPlaying()
    {
        return wrongSFX.isPlaying;
    }
}
