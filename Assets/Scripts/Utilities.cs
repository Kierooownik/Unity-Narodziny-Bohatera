using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class Utilities
{
    public static int playerDeaths = 0;
    public static string UpdateDeathCount(ref int countReference)
    {
        countReference = +1;
        return "Nast�pnym razem liczba �mierci gracza b�dzie wynosi�a " + countReference;
    }
    public static void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
        Debug.Log("Liczba �mierci gracza: " + playerDeaths);
        string message = UpdateDeathCount(ref playerDeaths);
        Debug.Log("Liczba �mierci gracza: " + playerDeaths);
    }
    public static bool RestartLevel(int sceneIndex)
    {
        if (sceneIndex < 0)
        {
            throw new System.ArgumentException("Indeks sceny nie mo�e by� ujemny.");
        }
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1.0f;
        return true;
    }
    
}
