using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour //Script do Menu
{
    //void do carregamento do Game
    public void LoadGame()
    {
        //chamar a sena 01
        SceneManager.LoadScene(1);
    }
}
