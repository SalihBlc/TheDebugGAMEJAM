using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pasueAndfast : MonoBehaviour
{
    private bool pauseGame = false;
    public float pauseDuration = 3f;
    public TMP_Text countDownText;

    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (pauseGame)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("pause"))
        {
            StartCoroutine(PauseCorotine());
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("fast"))
        {
            Speed();
            Destroy(other.gameObject);
        }
    }
    IEnumerator PauseCorotine()
    {
        pauseGame = true;
        Time.timeScale = 0;
        countDownText.gameObject.SetActive(true);
        for (int i = 3; i > 0; i--)
        {
            countDownText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }
        countDownText.text = "GO!";
        yield return new WaitForSecondsRealtime(1f);
        pauseGame = false;
        Time.timeScale = 1;
        countDownText.gameObject.SetActive(false);
    }
    void Speed()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.drag = 1f;
        Time.timeScale = 10f;
        Invoke("ResetTimeScale", 2f);
    }
    void ResetTimeScale()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.drag = 4f;
        Time.timeScale = 1f;
    }
}
