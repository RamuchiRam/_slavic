using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] private int level;
    public void LoadScene(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        LoadScene(level);
    }
}
