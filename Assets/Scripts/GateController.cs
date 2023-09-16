using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateController : MonoBehaviour
{
    [SerializeField] private GameObject _startingSceneTransition;
    [SerializeField] private GameObject _startingSceneTransition1;
    [SerializeField] private GameObject _endingSceneTransition;
    public string Gameplay;

    private bool isTransitioning = false;

    private void Start()
    {
        Collider collider = gameObject.AddComponent<BoxCollider>();

        ((BoxCollider)collider).size = new Vector3(1f, 1f, 1f);
        ((BoxCollider)collider).center = new Vector3(0f, 1f, 0f);

        _startingSceneTransition1.SetActive(true);
        StartCoroutine(DisableStartingSceneTransition(2f));
    }

    private IEnumerator DisableStartingSceneTransition(float delay)
    {
        yield return new WaitForSeconds(delay);
        _startingSceneTransition1.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning || !collision.gameObject.CompareTag("Cube"))
            return;

        isTransitioning = true;

        _startingSceneTransition.SetActive(true);

        StartCoroutine(StartSceneTransition());
    }

    private IEnumerator StartSceneTransition()
    {
        yield return new WaitForSeconds(2f);

     
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(Gameplay);


        while (!loadOperation.isDone)
        {
            yield return null;
        }
        
        _endingSceneTransition.SetActive(true);
        _startingSceneTransition.SetActive(false);

        yield return new WaitForSeconds(2f);
        _endingSceneTransition.SetActive(false);

        isTransitioning = false;
    }
}
