using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject weaponFab;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0,0,90);
    }
    // Start is called before the first frame update
    public void Throw()
    {
        Instantiate(weaponFab);
    }
}
