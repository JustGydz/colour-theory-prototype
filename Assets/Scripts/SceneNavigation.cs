using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
 public void LoadColourScene()
	{
		SceneManager.LoadScene(1);
	}
 public void LoadMonochromeScene()
	{
		SceneManager.LoadScene(2);
	}
 public void LoadMenuScene()
	{
		SceneManager.LoadScene(0);
	}

public void QuitScene()
	{
		Application.Quit();
	}
}
