using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class WallSFX : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _wallSounds;
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
        
        StartCoroutine(PlayRandomClip());
    }
    
    private IEnumerator PlayRandomClip()
    {
        yield return new WaitForSeconds(noiseFrequency);
        if (_audioSource.isPlaying || !(distanceToPlayer <= maxDistance)) yield break;
        
        var randomIndex = Random.Range(0, _wallSounds.Count);
        _audioSource.clip = _wallSounds[randomIndex];

        _audioSource.volume = 1;
        _audioSource.Play();
    }
}
