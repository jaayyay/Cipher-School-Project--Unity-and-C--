using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Coin : MonoBehaviour

{

private void OnTriggerEnter(Collider other)

{

if(other.gameObject.tag == "Player")

{
Invoke("DestroyCollectables", 0.1f);

}

}


void DestroyCollectables()

{

Destroy(this.gameObject);
}
}