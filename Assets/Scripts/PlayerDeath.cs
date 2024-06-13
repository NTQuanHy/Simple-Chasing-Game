using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private AudioSource deathSoundEffect;
    private Rigidbody2D rb;
    private Animator anima;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            HealthManager.health--;
            if(HealthManager.health <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(getHurt());
            }
        }
    }

    IEnumerator getHurt()
    {
        GetComponent<Animator>().SetLayerWeight(1, 1);
        Physics2D.IgnoreLayerCollision(6, 8);
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;   
        anima.SetTrigger("death");
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
