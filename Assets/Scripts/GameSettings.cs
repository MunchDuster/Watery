using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
	public static GameSettings current;

	private void Awake() 
	{
		if(current == null)
		{
			//set this component as the current
			current = this;
			//dont destroy when hcnaging scenes
			DontDestroyOnLoad(gameObject);
		}
	}
	//Delegates for when a value changes
	public delegate void OnFloatChanged(float value);
	public OnFloatChanged OnMusicVolumeChanged;
	public OnFloatChanged OnFXVolumeChanged;
	public OnFloatChanged OnTextSizeChanged;
	public OnFloatChanged OnSensitivityChanged;

	public delegate void OnBoolChanged(bool value);
	public OnBoolChanged OnMotionBlurChanged;

	//private vars to hold value
	private float _fxVolume;
	private float _musicVolume;
	private float _textSize;
	private float _sensitivity;
	private bool _motionBlur; 

	//these are public variables that, when a value is set, the respective OnSomethingChanged event is fired.
	public float fxVolume
    {
        set
        {
        	_fxVolume = value;
			if(OnFXVolumeChanged != null) OnFXVolumeChanged(value);
        }
        get
        {
            return _fxVolume;
        }
	}
	public float musicVolume
    {
        set
        {
        	_musicVolume = value;
			if(OnMusicVolumeChanged != null) OnMusicVolumeChanged(value);
        }
        get
        {
            return _musicVolume;
        }
	}
	public float textSize
	{
		set
		{
			_textSize = value;
			if(OnTextSizeChanged != null) OnTextSizeChanged(value);
		}
		get
		{
			return _textSize;
		}
	}
	public float sensitivity
	{
		set
		{
			_sensitivity = value;
			if(OnSensitivityChanged != null) OnSensitivityChanged(value);
		}
		get
		{
			return _sensitivity;
		}
	}
	public bool motionBlur
	{
		set
		{
			_motionBlur = value;
			if(OnMotionBlurChanged != null) OnMotionBlurChanged(value);
		}
		get
		{
			return _motionBlur;
		}
	}
}