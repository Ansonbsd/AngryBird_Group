using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioClip birdCollison;
    public AudioClip birdSelect;
    public AudioClip birdFlying;
    public AudioClip[] pigCollisons;
    public AudioClip woodCollision;
    public AudioClip woodDestoryed;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayBirdCollison(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(birdCollison, position, 1f);
    }
    public void PlayBirdSelect(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(birdSelect, position, 1f);
    }
    public void PlayBirdFlying(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(birdFlying, position, 1f);
    }
    public void PlayPigCollision(Vector3 position)
    {
        int randomIndex = Random.Range(0, pigCollisons.Length);
        AudioClip ac = pigCollisons[randomIndex];
        AudioSource.PlayClipAtPoint(ac, position, 1f);
    }
    public void PlayWoodCollision(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(woodCollision, position, .3f);
    }
    public void PlayWoodDestroyed(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(woodDestoryed, position, .2f);
    }

}
