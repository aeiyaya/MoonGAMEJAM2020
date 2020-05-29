using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class SplashManager : MonoBehaviour
{

    public float SplashScreenTime = 3f; // Shows splash screen for N seconds
    public float FadeOutTime = 1f;

    private float time = 0f;
    private bool goneToMenu = false;
    

    public CanvasGroup splashScreen;

    private IEnumerator fade;
    private void Start()
    {
        time = 0f;
        splashScreen.alpha = 0;
        fade = FadeInAndOut(true);
    }

    private void Update()
    {
        if (time >= SplashScreenTime && !goneToMenu)
            GoToMenu();
        else
            time += Time.deltaTime;


        if (Input.anyKeyDown)
        {
            GoToMenu();
        }
    }

    
    public void GoToMenu()
    {
        goneToMenu = true;
        if (fade != null)
        {
            StopCoroutine(fade);

            fade = FadeInAndOut(true);

            StartCoroutine(fade);
        }
    }


    IEnumerator FadeInAndOut(bool fadeIn)
    {
        float startTime = 0;

        while (startTime < FadeOutTime)
        {
            if (fadeIn)
                splashScreen.alpha += FadeOutTime * Time.deltaTime;
            else
                splashScreen.alpha -= FadeOutTime * Time.deltaTime;

            startTime += FadeOutTime * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        if (!fadeIn)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
