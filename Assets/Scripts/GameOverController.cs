using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverController : MonoBehaviour {


	public AudioSource playAgainAudio;

    /// <summary>
    /// Volta para o jogo novamente
    /// </summary>
	public void PlayAgain(){
		playAgainAudio.Play ();
        UnityAdControle.ShowAdReward();
		SceneManager.LoadScene (1);
	}

    /// <summary>
    /// Retorna para o menu inicial
    /// </summary>
	public void QuitGame(){
		SceneManager.LoadScene(0);
	}

}
