using UnityEngine;

public class RedLitmus : Interactable
{
	public GameObject particlePrefab;

	public override void Interact(Interactable other)
	{
		TestTube testube = other as TestTube;

		// Create a particle effect
		Instantiate(particlePrefab, transform.position, transform.rotation);

		//Chagne color accordingly
		if (testube.contents.makesLitmusBlue)
		{
			GetComponent<Renderer>().material.color = Color.blue;
		}
		else
		{
			GetComponent<Renderer>().material.color = Color.red;
		}
	}
	public override InteractionInfo WouldInteract(Interactable other)
	{
		if (other.GetType().Name == "TestTube")
		{
			if ((other as TestTube).contents != null)
			{
				return InteractionInfo.Success("add red litmus");
			}
			else
			{
				return InteractionInfo.Problem("Cant mix with nothing.");
			}
		}
		else
		{
			return InteractionInfo.Problem("Test tube can only interact with other test tubes and chemicals");
		}
	}
}
