using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSoundEffects : MonoBehaviour
{
    [SerializeField]AudioSource whistleSFX, wrongSFX;
    [SerializeField] AudioSource[] compassSFX;

    [SerializeField] RhythmInput rhythm;

    public void PlayCompass(float delay)
    {
        compassSFX[rhythm.CurrentCombo].PlayDelayed(delay);
    }
    public void PlayWhistle()
    {
        whistleSFX.Play();
    }
    public void PlayWrong()
    {
        wrongSFX.Play();
    }

    public bool IsWhistlePlaying()
    {
        return whistleSFX.isPlaying;
    }

    public bool IsCompassPlaying()
    {
        foreach (AudioSource audio in compassSFX)
            if (audio.isPlaying)
                return true;
        
        return false;
    }
    
    public void ShutUp()
    {
        foreach (AudioSource audio in compassSFX)
            if (audio.isPlaying)
                audio.Stop();
    }
}
