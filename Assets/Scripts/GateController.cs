using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateController : MonoBehaviour
{
    [SerializeField] private GameObject _startingSceneTransition;
    [SerializeField] private GameObject _endingSceneTransition;
    public string Gameplay;

    private void Start()
    {
        Collider collider = gameObject.AddComponent<BoxCollider>();

        _startingSceneTransition.SetActive(true);
        Invoke("DisableStartingSceneTransition", 5f);
    }

    private void DisableStartingSceneTransition()
    {
        _startingSceneTransition.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            SceneManager.LoadScene(Gameplay);
            _startingSceneTransition.SetActive(true);
            StartCoroutine(FunctionTimer.Start(1.5f, LoadNextLevel));
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene("Gameplay2");
    }
}
