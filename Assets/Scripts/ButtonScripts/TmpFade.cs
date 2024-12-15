using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TmpFade : MonoBehaviour
{
    [Header("Fade Settings")]
    public float fadeDuration = 2f;
    private TMP_Text _textComponent;
    private string _lastText = "";
    private Coroutine _fadeCoroutine;

    private void Awake()
    {
        _textComponent = GetComponent<TMP_Text>();
        _textComponent.enabled = false;
    }

    private void Update()
    {
        if (_textComponent.text != _lastText)
        {
            _textComponent.enabled = true;
            _lastText = _textComponent.text;
            OnTextChanged();
        }
    }

    private void OnTextChanged()
    {
        SetAlpha(1f);
        if (_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }
        _fadeCoroutine = StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color color = _textComponent.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }

        SetAlpha(0f);
        EndText();
    }

    private void SetAlpha(float alpha)
    {
        Color color = _textComponent.color;
        color.a = alpha;
        _textComponent.color = color;
    }

    private void EndText()
    {
        _textComponent.enabled = false;
        _textComponent.text = "";
        _lastText = "";
    }
}
