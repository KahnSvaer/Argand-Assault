using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnParticleCollision(GameObject other) {
        Destroy(gameObject);
        Debug.Log(other.gameObject.name);;
    }
}
