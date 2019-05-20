using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PreviewBlock : MonoBehaviour
{

    public Camera camera;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
