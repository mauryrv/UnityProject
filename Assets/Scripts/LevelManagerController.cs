using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManagerController : MonoBehaviour {

	public AudioSource playGameAudio;
	public AudioSource gameOverAudio;

    /// <summary>
    /// Carrega a fase.
    /// </summary>
    /// <param name="scene">Scene.</param>
	public void LoadScene(int scene){

		playGameAudio.Play();
		SceneManager.LoadScene(scene);
	}

    /// <summary>
    /// Sai do jogo
    /// </summary>
	public void QuitGame(){
		gameOverAudio.Play();

		Application.Quit();
	}
}
