using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    // Start is called before the first frame update
    float time = 60f;
    public Image fillImage; // Reference to the Image component
    Coroutine coroutine;

    public static TimerScript instance;
    void Start()
    {
        fillImage = GetComponent<Image>();
        // coroutine = StartCoroutine(ChangeFillAmountOverTime());
        Invoke("RestartTimer", 5f);
        instance = this;
    }

    public void RestartTimer()
    {
        if (coroutine != null)
        {

            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(ChangeFillAmountOverTime());

    }

    [ContextMenu("RestartTimer")]
    public void RestartTimerContextMenu()
    {
        if (coroutine != null)
        {

            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(ChangeFillAmountOverTime());

    }
    public float duration; // Total time for the fill change (in seconds)

    IEnumerator ChangeFillAmountOverTime()
    {
        fillImage.fillAmount = 1;
        float startFillAmount = fillImage.fillAmount; // Start value (1)
        float endFillAmount = 0f; // End value (0)

        float timeElapsed = 0f; // Time tracker

        while (timeElapsed < duration)
        {
            // Calculate the new fill amount based on the elapsed time
            float newFillAmount = Mathf.Lerp(startFillAmount, endFillAmount, timeElapsed / duration);

            // Set the new fill amount
            fillImage.fillAmount = newFillAmount;

            // Increment the elapsed time
            timeElapsed += Time.deltaTime;

            // Wait until the next frame
            yield return null;
        }

        string sceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(sceneName);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
