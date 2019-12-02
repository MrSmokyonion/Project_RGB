using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public RectTransform m_circle;
    public Image m_press;
    public Slider m_progress;

    private bool m_isTouched;

    private void Start()
    {
        m_isTouched = false;

        StartCoroutine(crt_SpinCircle());
        StartCoroutine(crt_FadePress());
    }

    public void StartGame()
    {
        if (m_isTouched) return;

        Debug.Log("터치했다 씝새꺄");
        m_isTouched = true;
    }

    private IEnumerator crt_SpinCircle()
    {
        yield return null;

        float nextAngle = 0f;
        while(true)
        {
            yield return new WaitForEndOfFrame();

            nextAngle += 0.1f;
            m_circle.rotation = Quaternion.Euler(m_circle.rotation.x, m_circle.rotation.y, nextAngle);
        }
    }

    private IEnumerator crt_FadePress()
    {
        yield return null;

        Color fadeColor = m_press.color;

        float start = 0f;
        float end = 1f;
        float time = 0f;
        float fadeTime = 1f;

        while(!m_isTouched)
        {
            yield return new WaitForEndOfFrame();

            time += Time.deltaTime / fadeTime;
            fadeColor.a = Mathf.Lerp(start, end, time);
            m_press.color = fadeColor;

            if(time > fadeTime)
            {
                float tmp = start;
                start = end;
                end = tmp;
                time = 0f;
            }
        }
        m_press.color = Color.clear;
        StartCoroutine(crt_LoadScene());

        yield return null;
    }

    private IEnumerator crt_LoadScene()
    {
        yield return null;
        m_progress.gameObject.SetActive(true);

        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("InputTestRoom");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;
            if (m_progress.value < 0.9f)
            {
                m_progress.value = Mathf.MoveTowards(m_progress.value, 0.9f, Time.deltaTime);
            }
            else if (operation.progress >= 0.9f)
            {
                m_progress.value = Mathf.MoveTowards(m_progress.value, 1f, Time.deltaTime);
            }

            if (m_progress.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }
    }
}
