using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour {

    public static bool pause;

    [SerializeField]
    [Tooltip("Referencia para o menu pause")]
    private GameObject menuPause;

    /// <summary>
    /// Metodo para reiniciar a tela do jogo
    /// </summary>
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Metodo para pausar o jogo
    /// </summary>
    /// <param name="isPausado"></param>
    public void SetMenuPause(bool isPausado) {
        pause = isPausado;

        // Se o jogo estiver pausado timescale recebe 0

        Time.timeScale = (pause) ? 0 : 1;

        // deixa o MenuPause-Panel ativado/desativado
        menuPause.SetActive(pause);
    }

    public void CarregaScene(string nomeScene) {
        SceneManager.LoadScene(nomeScene);
    }

    private void Start() {
        pause = false;
        menuPause.SetActive(pause);
#if !UNITY_ADS
        SetMenuPause(false);
#endif
    }
}
