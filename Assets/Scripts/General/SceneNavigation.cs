using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
 public void LoadMenuScene()
	{
		SceneManager.LoadScene(0);
	}

 public void LoadColourScene()
	{
		SceneManager.LoadScene(1);
	}

 public void LoadMonochromeScene()
	{
		SceneManager.LoadScene(2);
	}

public void LoadBossRoomScene()
	{
		SceneManager.LoadScene(3);
	}

	public void LoadWorldsHubScene()
	{
		SceneManager.LoadScene(4);
	}

	public void LoadRedRestScene()
	{
		SceneManager.LoadScene(5);
	}

	public void LoadGreenRestScene()
	{
		SceneManager.LoadScene(6);
	}

	public void LoadBlueRestScene()
	{
		SceneManager.LoadScene(7);
	}

	public void QuitScene()
	{
		Application.Quit();
	}
}
