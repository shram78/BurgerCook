using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PointUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointText;

    public void OnShow(int currentPoint)
    {
        _pointText.gameObject.SetActive(true);

        _pointText.text = " + " + currentPoint.ToString();
    }
}
