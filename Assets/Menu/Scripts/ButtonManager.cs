using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject Settings;
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private Slider EffectSlider;

        
    public void Start()
    {
        VolumeSlider.onValueChanged.AddListener (delegate {OnVolumeChange();});
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
        Debug.Log (VolumeSlider.value);
    }
    
    public void OnEffectChange()
    {
        Debug.Log (EffectSlider.value);
    }
}
