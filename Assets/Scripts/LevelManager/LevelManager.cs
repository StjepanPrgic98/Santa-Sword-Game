using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager
{
    public static void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
