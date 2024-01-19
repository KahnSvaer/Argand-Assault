using System;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{   
    [SerializeField] ParticleSystem EnemyCrashVFX;
    [SerializeField] int hitPoints;

    Transform parent;
    ScoreBoard scoreBoard;


    private void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parent = GameObject.FindWithTag("ParticleHolder").transform;
    }

    private void OnParticleCollision(GameObject other)
    {
        HitSequence();
    }

    private void HitSequence()
    {
        hitPoints-=1;
        UpdateScore();
        if (hitPoints<=0)
        {
            CrashSequence();
        }
    }

    private void UpdateScore()
    {
        float score = transform.localScale.x+transform.localScale.y+transform.localScale.z; //Basically some function to quantify scores
        score = MathF.Round(score);
        scoreBoard.GetComponent<ScoreBoard>().IncreaseScore((int)score);
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
