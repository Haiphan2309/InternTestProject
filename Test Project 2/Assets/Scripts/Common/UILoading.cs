using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UILoading : MonoBehaviour
{
    [SerializeField] Gradient gradient;
    [SerializeField] RectTransform blackImage;
    [SerializeField] Slider progressSlider;
    [SerializeField] Image fillImage;

    public bool isDoneLoading;

    public void LoadNewScene()
    {
        StartCoroutine(Cor_LoadNewScene());
        blackImage.anchoredPosition = new Vector2(3500, 0);
        progressSlider.transform.localScale = Vector2.zero;
        progressSlider.value = 0;
        isDoneLoading = false;
    }
    void UpdateSliderColor()
    {
        float normalizedHealth = progressSlider.value / progressSlider.maxValue;
        fillImage.color = gradient.Evaluate(normalizedHealth);
    }
    IEnumerator Cor_LoadNewScene()
    {
        blackImage.DOAnchorPosX(0, 0.8f);
        yield return new WaitForSeconds(0.8f);
        progressSlider.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 10; i++)
        {
            progressSlider.value = i/10f;
            UpdateSliderColor();
            yield return new WaitForSeconds(0.1f);
        }
        progressSlider.transform.DOScale(0, 0.3f);
        yield return new WaitForSeconds(0.5f);
        isDoneLoading = true;
        blackImage.DOAnchorPosX(-3500, 0.8f);
    }
}
