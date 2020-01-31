using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve fadeCurve;
    void Start()
    {
        StartCoroutine(FadeIn());    
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));

    }
    IEnumerator FadeIn()    //this is a coroutine
    {
        float t = 1f;

        while (t > 0)
        {
            t -= Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            img.color = new Color(0f, 55f, 70f, a);  //unity don't le tme change the alpha value alone i have to set RGB and the alpha at the same time.
            yield return 0;  //yield is for waiting a signle frame for checking if time  has reached to 0.
        }
       

    }
    IEnumerator FadeOut(string scene)    //this is a coroutine
    {
        float t = 0f;

        while (t <1f)
        {
            t += Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            img.color = new Color(0f, 55f, 70f, a);  //unity don't le tme change the alpha value alone i have to set RGB and the alpha at the same time.
            yield return 0;  //yield is for waiting a signle frame for checking if time  has reached to 0.
        }
        SceneManager.LoadScene(scene);
       

    }
}
