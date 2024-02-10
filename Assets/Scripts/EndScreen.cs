using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene(1);
    }
}
