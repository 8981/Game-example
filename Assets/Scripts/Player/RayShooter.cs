using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        int size = 24;
        float posX = _camera.pixelWidth/2 - size/4;
        float posY = _camera.pixelHeight/2 - size/4;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject; //get the object which was hit
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>(); 
                if (target != null) //check componet ReactiveTarget in hitting object
                {
                    target.ReactToHit(); //calling a method on the target instead of generating a debug message
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point)); //the response of the program in response to a hit
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)

    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}
