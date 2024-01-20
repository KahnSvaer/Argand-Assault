using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake() {
        int count = FindObjectsOfType<MusicPlayer>().Length;
        if (count > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
