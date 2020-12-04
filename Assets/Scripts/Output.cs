using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Output : MonoBehaviour
{
    public GameObject output;
    public float waitTime = 1.5f;

    private TextMeshProUGUI text;


    public void Start()
    {
        text = output.GetComponent<TextMeshProUGUI>();
        output.SetActive(false);
    }

    public void SetOutput(bool state)
    {
        output.SetActive(true);

        if (state)
        {
            text.text = "Correct";
            text.color = new Color32(0, 171, 31, 255);
        }
        else
        {
            text.text = "Incorrect";
            text.color = new Color32(255, 37, 0, 255);
        }
        StartCoroutine(Close());
    }

    private IEnumerator Close()
    {
        yield return new WaitForSeconds(waitTime);
        output.SetActive(false);
    }
}
