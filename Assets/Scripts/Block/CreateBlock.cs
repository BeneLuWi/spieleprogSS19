using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    public GameObject block;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 posInGrid = transform.position + (transform.forward * 4);

        if (Input.GetMouseButtonDown(0))
        {
            posInGrid.x = (float)System.Math.Floor(posInGrid.x);
            posInGrid.y = (float)System.Math.Floor(posInGrid.y);
            posInGrid.z = (float)System.Math.Floor(posInGrid.z);

            Instantiate(block, posInGrid, Quaternion.identity);
        }
        

        // Preview Block
        

    }
}
