using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    
    [SerializeField] private AudioSource musicSource;
    // [SerializeField] private AudioSource sfxSource;

    [SerializeField] private AudioClip music;
    private bool musicPlaying = true;
    // [SerializeField] private AudioClip paperCrumple;

    private bool muted = false;
    [SerializeField] private Image muteImg;
    [SerializeField] private Sprite soundSprite;
    [SerializeField] private Sprite mutedSprite;
    [SerializeField] private Slider volumeSlider;
    private float volume = 1;

    private void Start(){
        volumeSlider.value = PlayerPrefs.GetFloat("volume",1);
        SetVolume();
        SetMute(PlayerPrefs.GetInt("soundMuted",0) == 1);
    }

    public void ToggleMute(){
        SetMute(!muted);
    }

    private void SetMute(bool m){
        muted = m;
        PlayerPrefs.SetInt("soundMuted", muted ? 1 : 0);

        if (muted){
            muteImg.sprite = mutedSprite;
            musicSource.enabled = false;
            // sfxSource.enabled = false;
        }
        else{
            muteImg.sprite = soundSprite;
            musicSource.enabled = true;
            // sfxSource.enabled = true;
            if (musicPlaying) PlayMusic();
        }
    }

    public void PlayMusic(){
        musicSource.clip = music;
        musicSource.Play();
        musicPlaying = true;
    }

    public void PauseMusic(){
        musicSource.Pause();
        musicPlaying = false;
    }

    public void StopMusic(){
        musicSource.Stop();
        musicPlaying = false;
    }

    // public void PlayPaperCrumple(){
    //     sfxSource.PlayOneShot(paperCrumple);
    // }

    public void SetVolume(){
        musicSource.volume = volumeSlider.value;
        // sfxSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        
        if (volumeSlider.value <= 0){ //if the slider is at 0, that counts as muted
            SetMute(true);
        }
        else if (muted){ //else we're now not muted
            SetMute(false);
        }
    }

}
