using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public float vida = 100;
    public Image barradevida;

    private void Start()
    {

    }

    private void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100);
        barradevida.fillAmount = vida / 100;

        if(vida <= 0)
        {
            Time.timeScale = 0f;
            GameOverManager.gameOverManager.CallGameOver();
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}