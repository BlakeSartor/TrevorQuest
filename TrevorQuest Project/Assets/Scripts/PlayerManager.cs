using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    public void KillPlayer()
    {
        // KILL PC
        // Reload Starting Scene for now
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}