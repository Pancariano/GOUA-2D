using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    private Scene _scene;
    [SerializeField] private int _sceneIndex;

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            SceneManager.LoadScene(_scene.buildIndex+1);
            //SceneManager.LoadScene(_sceneIndex);
        }
    }

    private void StartLevel()
    {
        SceneManager.LoadScene(_scene.buildIndex + 1);
    }
}