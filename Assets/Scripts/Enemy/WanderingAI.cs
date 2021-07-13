using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    public bool _alive; //variable for check consist life or dead
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

     void Start()
    {
        _alive = true; //initialise variable
    }

    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime); //moves straight in spite of the bends
            Ray ray = new Ray(transform.position, transform.forward); //the beam is aimed in the direction of sight of the object
            RaycastHit hit;
            
            
            if (Physics.SphereCast(ray, 0.75f, out hit)) //we throw a ray with a circle described around it
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange) 
                {
                    float angle = Random.Range(-110, 110); //turn with half random direction
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
