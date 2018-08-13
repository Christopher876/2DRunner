using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

	public GameObject loadingScreen;
	public Slider slider;

	public void LoadLevel(int scene)
	{
		StartCoroutine(LoadAsynchronously(scene));
	
	}

	IEnumerator LoadAsynchronously (int scene)
	{
		AsyncOperation SceneLoading = SceneManager.LoadSceneAsync(scene);

		loadingScreen.SetActive(true);

		while (!SceneLoading.isDone)
		{
			float progress = Mathf.Clamp01(SceneLoading.progress / 0.9f);
			slider.value = progress;
			Debug.Log(SceneLoading.progress);
			yield return null;
		}
	}
}
