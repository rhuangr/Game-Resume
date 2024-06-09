using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{

    

    [SerializeField] AudioSource[] myAudioSource;

    [SerializeField] GameObject slider;
    public AudioSource currentAudio;

    private float previousVolume;

    

    private void Start() {
        
        DontDestroyOnLoad(gameObject);
        myAudioSource = GetComponents<AudioSource>();
        playMainMenuMusic();
        previousVolume = currentAudio.volume;
        slider.GetComponent<Slider>().value = currentAudio.volume;
    }

    public void mute(){
        if (currentAudio.volume != 0){
            previousVolume = currentAudio.volume;
        }
        
        currentAudio.volume = 0;
    }

    public void changeVolume(){
        currentAudio.volume = slider.GetComponent<Slider>().value;
    }

    public void unmute(){
        currentAudio.volume = previousVolume;
    }
    public void clickSFX(){
        myAudioSource[0].Play();
    }

    public void playMainMenuMusic(){
        stopMusic();
        currentAudio = myAudioSource[1];
        myAudioSource[1].Play();
    }

    public void playHouseJazz(){
        stopMusic();
        currentAudio = myAudioSource[2];
        Debug.Log("playin house jazz");
        myAudioSource[2].Play();
    }
    public void playChord(){
        
        myAudioSource[3].Play();
    }

    private void stopMusic(){
        if (currentAudio != null){
            currentAudio.Stop();
        }
    }
}
