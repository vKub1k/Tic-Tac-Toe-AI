using UnityEngine;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] GameObject _intro;

    public void _PlayIntroSound()
    {
        _audioSource.Play();
    }

    public void _HideIntro()
    {
        _intro.SetActive(false);
    }
}
