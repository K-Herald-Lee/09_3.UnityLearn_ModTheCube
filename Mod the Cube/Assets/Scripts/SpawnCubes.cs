using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject _cube;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(_cube, transform.position, _cube.transform.rotation);
        }        
    }
}
