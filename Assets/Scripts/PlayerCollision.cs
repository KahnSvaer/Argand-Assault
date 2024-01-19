using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] float reloadDeley = 1f;
    [SerializeField] ParticleSystem explosionVFX;
    private void OnCollisionEnter(Collision other)
    {
        CrashSequence();
    }

    private void CrashSequence()
    {
        if(!explosionVFX.isPlaying)
        {
            explosionVFX.Play();
        }
        GetComponent<OldInputController>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        Invoke("ReloadLevel", reloadDeley);
    }

    private void ReloadLevel()
    {
        int currantSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currantSceneIndex);
    }
}
