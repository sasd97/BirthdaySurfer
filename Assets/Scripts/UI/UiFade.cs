using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[AddComponentMenu("UI/Controllers/Fade Script")]
public class UiFade: MonoBehaviour
{

    [Header("Fade Attributes")]
    [SerializeField] private Image _image;
    [SerializeField] private AnimationCurve _animationCurve;

    public void FadeInAsync()
	{
	    StartCoroutine(FadeInSync());
	}

    public void FadeToAsync(string sceneName)
    {
        StartCoroutine(FadeOutSync(sceneName));
    }

    private IEnumerator FadeInSync()
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

    private IEnumerator FadeOutSync(string sceneName)
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
