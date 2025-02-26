using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Gameplay Variables")]

    [SerializeField] int hitPoints = 100;

    [SerializeField] int scoreValue = 100;

    [Space(10)]

    [Header("Enemy Design Variables")]

    [SerializeField] GameObject destroyedVFX;
    

    Scoreboard scoreboard;

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessDamage();

    }

    private void ProcessDamage()
    {
        hitPoints -= 10;

        if (hitPoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
