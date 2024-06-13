using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelselect : MonoBehaviour
{
    public void openLevel(int levelId)
    {
        string levelName = "Level "+ levelId;
        SceneManager.LoadScene(levelName);
    }
}
