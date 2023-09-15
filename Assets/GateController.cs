using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateController : MonoBehaviour
{
    public string Gameplay;
    private void Start()
    {
        Collider collider = gameObject.AddComponent<BoxCollider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cube"))
        {
            SceneManager.LoadScene(Gameplay);
        }
    
    }

}


