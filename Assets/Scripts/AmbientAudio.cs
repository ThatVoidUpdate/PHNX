using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudio : MonoBehaviour
{
    public AudioClip Ambience;
    public AudioClip[] Noises;

    private AudioSource AmbienceSource;
    private AudioSource NoiseSource;

    public float Timeout = 0;
    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        AmbienceSource = sources[0];
        NoiseSource = sources[1];

        AmbienceSource.loop = true;
        AmbienceSource.clip = Ambience;
        AmbienceSource.Play();

        NoiseSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= Timeout)
        {
            float SoundLength = PlayRandomNoise();
            Timeout = SoundLength + Random.Range(3f, 10f);
            currentTime = 0;
        }

        currentTime += Time.deltaTime;
    }

    float PlayRandomNoise()
    {
        AudioClip noise = Noises[Random.Range(0, Noises.Length)];
        NoiseSource.clip = noise;
        NoiseSource.Play();
        return noise.length;
    }
}

