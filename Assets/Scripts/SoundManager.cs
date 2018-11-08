using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    public AudioSource vfxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource ambianceSource;                 
    public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
    public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.

    AudioSource _vfxSourcePrefab;


    void Awake() {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);

        _vfxSourcePrefab = Resources.Load<AudioSource>("Prefabs/VfxSource");
    }


    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip, float pitch = 1) {
        /*//Set the clip of our efxSource audio source to the clip passed in as a parameter.
        vfxSource.clip = clip;

        //Play the clip.
        vfxSource.Play();*/
        var audioSource = Instantiate(_vfxSourcePrefab, transform);
        audioSource.clip = clip;
        audioSource.Play();
        StartCoroutine(DestroyOnEnd(audioSource, clip.length));
    }


    //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
    public void RandomizeSfx(params AudioClip[] clips) {
        //Generate a random number between 0 and the length of our array of clips passed in.
        int randomIndex = Random.Range(0, clips.Length);

        //Choose a random pitch to play back our clip at between our high and low pitch ranges.
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        PlaySingle(clips[randomIndex], randomPitch);
    }

    IEnumerator DestroyOnEnd(AudioSource audioSource, float audioLength) {
        yield return new WaitForSeconds(audioLength);
        Destroy(audioSource.gameObject);
    }

    public void ChangeMusicSpeed(float newSpeed){
        musicSource.pitch = newSpeed;
    }
}