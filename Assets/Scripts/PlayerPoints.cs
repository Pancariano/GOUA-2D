using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public int score;
    private AudioSource _audio;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
       _audio = GetComponent<AudioSource>();
       _text.text = ScoreManager.totalScore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectable"))
        {
            _audio.Play();
            Destroy(collision.gameObject);
            ScoreManager.totalScore++;           
            _text.text = ScoreManager.totalScore.ToString();
            //_text.text = $"Score: {(int)ScoreManager.totalScore}";
        }
    }
}