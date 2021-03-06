using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UserInput))]
public class PlayerMenu : MonoBehaviour
{

	public UnityEvent OnOpenSettings;
	public UnityEvent OnExitSettings;

	[HideInInspector]
	public GameObject settingsPanel;

	private void Start()
	{
		GetComponent<UserInput>().OnSettingsPressed += OnSettingsPressed;
	}
	private void OnDestroy()
	{
		GetComponent<UserInput>().OnSettingsPressed -= OnSettingsPressed;
	}

	public void OnSettingsPressed()
	{
		//toggle active
		settingsPanel.SetActive(!settingsPanel.activeSelf);

		if (settingsPanel.activeSelf)
		{
			//settings open
			if (OnOpenSettings != null) OnOpenSettings.Invoke();
			Time.timeScale = 0;
		}
		else
		{
			//settings closed
			if (OnExitSettings != null) OnExitSettings.Invoke();
			Time.timeScale = 1;
		}
	}
}