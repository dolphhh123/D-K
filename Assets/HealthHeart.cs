using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeart : MonoBehaviour
{
    public Sprite fullHeart, halfHeart, emptyHeart;
    private Image _heartImage;

    private void Awake()
    {
        _heartImage = GetComponent<Image>();
    }

    public void SetHeartImage(HeartState state)
    {
        _heartImage.sprite = state switch
        {
            HeartState.Full => fullHeart,
            HeartState.Half => halfHeart,
            HeartState.Empty => emptyHeart,
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
        };
    }
}