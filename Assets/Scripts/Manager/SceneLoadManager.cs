using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoadManager
{
    public static void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
