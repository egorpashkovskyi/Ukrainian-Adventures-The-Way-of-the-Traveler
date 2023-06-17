using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    private float _fateSpeed = 0.5f;
    private Image _fadeImage;

    IEnumerator Start()
    {
        _fadeImage = GetComponent<Image>();
        Color color = _fadeImage.color;

        while (color.a > 0)
        {
            color.a -= _fateSpeed * Time.deltaTime;
            _fadeImage.color = color;
            yield return null;
        }
    }
    
    public IEnumerator c_Alpha(float value, float time)
    {
        float k = 0.0f;
        Color c0 = _fadeImage.color;
        Color c1 = c0;
        c1.a = value;
 
        while ((k += Time.deltaTime) <= time)
        {
            _fadeImage.color = Color.Lerp(c0, c1, k / time);
 
            yield return null;
        }
 
        _fadeImage.color = c1;
    }
    
}
