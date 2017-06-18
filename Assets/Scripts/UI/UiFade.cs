using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiFade: MonoBehaviour
{

    [Header("Fade Attributes")]
    [SerializeField] private Image _image;
    [SerializeField] private AnimationCurve _animationCurve;

	void Start ()
	{
	    StartCoroutine(FadeIn());
	}

    public void FadeTo(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    public IEnumerator FadeIn()
    {
        float deltaTime = 1f;

        while (deltaTime > 0f)
        {
            deltaTime -= Time.deltaTime;
            float alfa = _animationCurve.Evaluate(deltaTime);
            _image.color = new Color(0f, 0f, 0f, alfa);
            yield return 0;
        }
    }

    public IEnumerator FadeOut(string sceneName)
    {
        float deltaTime = 0f;

        while (deltaTime < 1f)
        {
            deltaTime += Time.deltaTime;
            float alfa = _animationCurve.Evaluate(deltaTime);
            _image.color = new Color(0f, 0f, 0f, alfa);
            yield return 0;
        }

        SceneManager.LoadScene(sceneName);
    }
}
