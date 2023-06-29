using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer instanceSP;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        if (instanceSP != null) Destroy(gameObject);
        else instanceSP = this;
        DontDestroyOnLoad(gameObject);

        _soundSlider.value = 0.3f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSoundVolume(float value)
    {
        _audioSource.volume = value;
    }
}
