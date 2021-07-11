using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        StartCoroutine(Die()); //method colling shotting scenes 
    }

    private IEnumerator Die() //overtun enemy, wait 1,5s and destroy him
    {
        this.transform.Rotate(0, 0, 75);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
    
}
