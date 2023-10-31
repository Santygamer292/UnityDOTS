using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    //cambiar de escena
  public void Jugar()
    {
        //cargar nueva escena con el numero o el nombre de la escena 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   
    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
