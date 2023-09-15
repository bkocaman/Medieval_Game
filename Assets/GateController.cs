using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Karakter objeye temas etti!");
    }

}


