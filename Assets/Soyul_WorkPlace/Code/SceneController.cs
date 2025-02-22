using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    Image image;

    private bool isFading;

    private void Awake()
    {
        image = GetComponent<Image>();

        isFading = false;
    }

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        for (float i = 1; i >= 0; i -= 0.03125f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, i);
            yield return null;
        }
        image.raycastTarget = false;
        yield break;
    }

    IEnumerator FadeOut(string where)
    {
        if (isFading) yield break;

        isFading = true;
        image.raycastTarget = true;
        for (float i = 0; i <= 1; i += 0.03125f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, i);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(where);
        yield break;
    }

    public void LoadScene(string where) { StartCoroutine(FadeOut(where)); }

    public void QuitGame()
    {
        Application.Quit();
    }
}