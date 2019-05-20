using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PreviewBlock : MonoBehaviour
{

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 playerpos = player.transform.position;
        Vector3 posInGrid = playerpos + (player.transform.forward * 4);

        posInGrid.x = (float)System.Math.Floor(posInGrid.x);
        posInGrid.y = (float)System.Math.Floor(posInGrid.y);
        posInGrid.z = (float)System.Math.Floor(posInGrid.z);

       
        transform.rotation = Quaternion.identity;
        transform.position = posInGrid;

        Collider[] colliders;
        colliders = Physics.OverlapSphere(transform.position, 1f /* Radius */);
        if (colliders.Length > 1) //Presuming the object you are testing also has a collider 0 otherwise
        {
            foreach (Collider c in colliders)
            {
                if(c.gameObject.transform.position == transform.position && c.gameObject.GetComponent<PreviewBlock>() != this)
                {
                    GameObject selectedGo = c.gameObject;

                    Block selectedBlock = selectedGo.GetComponent<Block>();

                    // Delete Block
                    if (Input.GetMouseButtonDown(1))
                    {
                        Destroy(selectedGo);
                    }
                    // Change Texture
                    else if (Input.GetKeyDown(KeyCode.R))
                    {
                        selectedBlock.nextTexture();
                    }
                }
            }




        }

    }
}
