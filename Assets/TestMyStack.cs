using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMyStack : MonoBehaviour
{
    [SerializeField]
    private Table _table;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() =>
        {
            _table.TestMyStack();
        });
    }
}
