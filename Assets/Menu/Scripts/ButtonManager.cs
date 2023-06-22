using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private TMP_Text MusicText;
    
    [SerializeField] private Slider EffectSlider;
    [SerializeField] private TMP_Text EffectText;

        
    public void Start()
    {
        MusicSlider.onValueChanged.AddListener (delegate {OnVolumeChange();});
        EffectSlider.onValueChanged.AddListener (delegate {OnEffectChange();});
    }
	
    
    
    public void ConfigButtonIN(Animator anim)
    {
        anim.SetBool("ConfigStatus", true);
    }
    
    public void ConfigButtonOUT(Animator anim)
    {
        anim.SetBool("ConfigStatus", false);
    }
    
    public void OnVolumeChange()
    {
        UserSettings.MusicVol = MusicSlider.value;

        MusicText.text = (int)(MusicSlider.value * 100) + "%";
    }
    
    public void OnEffectChange()
    {
        UserSettings.EffectVol = EffectSlider.value;

        EffectText.text = (int)(EffectSlider.value * 100) + "%";
    }
}
