using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] float reloadDeley = 1f;
    private void OnCollisionEnter(Collision other)
    {
        CrashSequence();
    }

    private void CrashSequence()
    {
        GetComponent<OldInputController>().enabled = false;
        GetComponent<Rigidbody>().useGravity = true;
        Invoke("ReloadLevel", reloadDeley);
    }

    private void ReloadLevel()
    {
        int currantSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currantSceneIndex);
    }
}
