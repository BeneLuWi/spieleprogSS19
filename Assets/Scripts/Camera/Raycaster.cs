using UnityEngine;
using System.Collections;

public class Raycaster : MonoBehaviour
{
    public Camera camera;
    int layerMask;
    public GameObject previewBlock;
    int rayLength = 8;

    void Start()
    {
        layerMask = 1 << 8;
        layerMask = ~layerMask;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);

        Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, rayLength, layerMask);
        
        Transform objectHit = hit.transform;

        if (hit.collider != null)
        {
            // Do something with the object that was hit by the raycast.
            objectHit.Translate(new Vector3(1f, 1f, 1f));
        }

        Vector3 point = ray.origin + (ray.direction * rayLength);

        point.x = (float)System.Math.Floor(point.x);
        point.y = (float)System.Math.Floor(point.y);
        point.z = (float)System.Math.Floor(point.z);


        previewBlock.transform.rotation = Quaternion.identity;
        previewBlock.transform.position = point;
        
    }
}