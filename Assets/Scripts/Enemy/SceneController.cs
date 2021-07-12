using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; //serialize variable for connect with tamplate 
    private GameObject _enemy; //the variable for whoching by enemy instance in the scene

    // Update is called once per frame
    void Update()
    {
        if(_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject; //Method coping object-tamplate
            _enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
