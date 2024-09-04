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
        if (currentAudio == myAudioSource[1]){
            return;
        }
        stopMusic();
        currentAudio = myAudioSource[1];
        myAudioSource[1].Play();
        currentAudio.volume = slider.GetComponent<Slider>().value;
    }

    public void playHouseJazz(){
        if (currentAudio == myAudioSource[2]){
            return;
        }
        stopMusic();
        currentAudio = myAudioSource[2];
        myAudioSource[2].Play();
        currentAudio.volume = slider.GetComponent<Slider>().value;
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
