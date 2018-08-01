using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdControle : MonoBehaviour {

    public static bool showAds = true;

    // Referencia para o obstaculo.
    //public static ObsComp obstaculo;

    public static DateTime? proxTempoReward = null;

    // Metodo para mostrar anuncio simples
    public static void ShowAd() {

        // Opcoes para o ad
        // Chamar o callback apos o anuncio finalizar
        ShowOptions opcoes = new ShowOptions();
        opcoes.resultCallback = Unpause;

        if (Advertisement.IsReady()) {
            Advertisement.Show(opcoes);
        }

        MenuPause.pause = true;
        Time.timeScale = 0;
    }

    /// <summary>
    /// Metodo para mostrar anuncio com recompensa
    /// </summary>
    public static void ShowAdReward() {
        proxTempoReward = DateTime.Now.AddSeconds(15);
        if (Advertisement.IsReady()) {
            MenuPause.pause = false;
            Time.timeScale = 0f;
            var opcoes = new ShowOptions {
                resultCallback = TratarMostrarResultado
            };
            Advertisement.Show(opcoes);
        }
    }


    /// <summary>
    /// Callback para tratar o jogo no ad com recompensa
    /// </summary>
    /// <param name="obj"></param>
    public static void TratarMostrarResultado(ShowResult obj) {
        switch (obj) {
            case ShowResult.Finished:
                // Anuncio mostrado. Continue o jogo
                //obstaculo.Continue();
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad pulado. Faz nada");
                break;
            case ShowResult.Failed:
                Debug.LogError("Erro no ad. Faz nada");
                break;
        }

        // Saia do modo pausado
        MenuPause.pause = false;
        Time.timeScale = 1f;
    }

    private static void Unpause(ShowResult obj) {
        //Quando o anuncio acabar 
        //sai do modo pausado
        MenuPause.pause = false;
        Time.timeScale = 1f;
    }
}
