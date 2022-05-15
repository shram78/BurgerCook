using UnityEngine;
using TMPro;
using DG.Tweening;


public class PointUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointText;
    [SerializeField] private GameObject _panelWidget;

    private RectTransform _rectTransfromWidget;

    private void Start()
    {
        _rectTransfromWidget = _panelWidget.GetComponent<RectTransform>();
    }

    public void OnShow(int currentPoint)
    {
        _pointText.gameObject.SetActive(true);

        _pointText.text = " + " + currentPoint.ToString();

        ScaleUp();
    }

    private void ScaleUp()
    {
        float interactionValue = 1.3f;
        float endValue = 0f;
        float timeToChange = 0.1f;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(_rectTransfromWidget.transform.DOScale(interactionValue, timeToChange));
        sequence.Insert(timeToChange, _rectTransfromWidget.transform.DOScale(endValue, 0.2f));
    }
}
