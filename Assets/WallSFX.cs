using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class WallSFX : MonoBehaviour
{
    [SerializeField] private AudioClip[] _wallSounds;
    [SerializeField] public float maxDistance;
    private AudioSource _audioSource;
    private readonly int noiseFrequency = 1;
    private float distanceToPlayer;
    private GameObject player;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (player == null)
        {
            Debug.Log("Player Not Found");
        }
    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(gameObject.transform.position, player.transform.position);
        
        if (!_audioSource.isPlaying && distanceToPlayer <= maxDistance)
        {
            StartCoroutine(PlayRandomClip());
        } else if (distanceToPlayer >= maxDistance)
        {
            StopCoroutine(PlayRandomClip());
        }
    }
    
    private IEnumerator PlayRandomClip()
    {
        int randomIndex = Random.Range(0, _wallSounds.Length);
        yield return new WaitForSeconds(noiseFrequency);
        _audioSource.clip = _wallSounds[randomIndex];
        
        _audioSource.volume = 1 - (distanceToPlayer / maxDistance);
        _audioSource.Play();
    }
}
