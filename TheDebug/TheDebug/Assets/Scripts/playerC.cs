using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playerC : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _text2;
    [SerializeField] private GameObject restartButton;

    private int totalHealth;
    public AudioSource debugVoice;

    void Start()
    {
        totalHealth = score.totalHealth;
        debugVoice = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("debug"))
        {
            Destroy(other.gameObject);
            score.totalScore++;
            _text.text = score.totalScore.ToString();


        }
        else if (other.gameObject.CompareTag("bug"))
        {
            Destroy(other.gameObject);
            totalHealth--;
            _text2.text = totalHealth.ToString();
            debugVoice.Play();
        }
        else if (other.gameObject.CompareTag("power"))
        {
            Destroy(other.gameObject);
            totalHealth++;
            _text2.text = totalHealth.ToString();
        }
        else if (other.gameObject.CompareTag("nextLevel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
    void Update()
    {
        if (totalHealth <= 0)
        {
            GameOVer();
        }

    }
    void GameOVer()
    {

        Time.timeScale = 0f;
        restartButton.SetActive(true);
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        score.totalHealth = 3;
        score.totalScore = 0;
        _text.text = score.totalScore.ToString();
        totalHealth = score.totalHealth;
        _text2.text = totalHealth.ToString();
        restartButton.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
