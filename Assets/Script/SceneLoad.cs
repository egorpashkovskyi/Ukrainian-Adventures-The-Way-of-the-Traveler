using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] private PlayerLogic _playerTrigger;
    [SerializeField] private ScreenFader _screenFader;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerTrigger._sceneTrigger = true;
            StartCoroutine(_screenFader.c_Alpha(0.0f, 3.0f));
        }
    }
    
}
