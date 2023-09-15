using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public GameObject firstWeapon;
    public GameObject secondWeapon;

    void Start()
    {
        firstWeapon.SetActive(true);
        secondWeapon.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (firstWeapon.activeSelf)
            {
                secondWeapon.SetActive(false);
                firstWeapon.SetActive(true);
            }
            else
            {
                secondWeapon.SetActive(true);
                firstWeapon.SetActive(false);
            }
        }
    }
}

