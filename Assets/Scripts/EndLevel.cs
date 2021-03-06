using UnityEngine;
using UnityEngine.Events;

public class EndLevel : MonoBehaviour
{
	public UnityEvent OnLevelEnd;
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			GameObject player = other.gameObject;
			Debug.Log(player);
			//Disable the playser movement
			PlayerMovement movement = player.GetComponent<PlayerMovement>();
			movement.enabled = false;

			//Unlock the player cursor
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;

			//Update level no if need be
			Debug.Log(GameSettings.current.currentLevel);
			Debug.Log(GameSettings.current.levelNo);
			if (GameSettings.current.currentLevel == GameSettings.current.levelNo)
			{
				GameSettings.current.levelNo++;
			}
			OnLevelEnd.Invoke();
		}
	}
}
