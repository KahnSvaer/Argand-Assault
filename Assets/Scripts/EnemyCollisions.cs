using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{   
    [SerializeField] ParticleSystem EnemyCrashVFX;
    [SerializeField] Transform parent;
    private void OnParticleCollision(GameObject other)
    {
        CrashSequence();
    }
    private void OnCollisionEnter(Collision other) 
    {
        CrashSequence();
    }

    private void CrashSequence()
    {
        Instantiate(EnemyCrashVFX, transform.position, Quaternion.identity, parent);
        Destroy(gameObject);
    }
}
