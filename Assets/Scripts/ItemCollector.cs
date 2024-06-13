using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int Orange = 0;
    [SerializeField] private Text OrangeText;
    [SerializeField] private AudioSource CollectSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Orange"))
        {
            CollectSoundEffect.Play();
            Destroy(collision.gameObject);
            Orange++;
            OrangeText.text = "Collected: " + Orange;
        }
    }
}
