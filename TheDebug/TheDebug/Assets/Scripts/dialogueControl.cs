using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class dialogueControl : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;




    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

    }


    void StartDialogue()
    {
        index = 0;
        StartCoroutine(LineType());
    }
    IEnumerator LineType()
    {

        foreach (char c in lines[index].ToCharArray())
        {

            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);

        }

    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(LineType());
        }
        else
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
