using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class KeyCap
{
    public KeyCode keyCode;
    public Button button;
}

public class KeyBoard : MonoBehaviour
{
    [SerializeField] private List<KeyCap> keyCaps = new List<KeyCap>();

    public Action<KeyCode> OnKeyPress;

    private static KeyBoard _instance;
    public static KeyBoard Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<KeyBoard>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        OnKeyCaps();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        OnKeyBoard();
#endif
    }

    private void OnKeyBoard()
    {
        foreach (var keyCap in keyCaps)
        {
            if (Input.GetKeyDown(keyCap.keyCode))
            {
                OnKeyPress.Invoke(keyCap.keyCode);
            }
        }
    }

    private void OnKeyCaps()
    {
        foreach (var keyCap in keyCaps)
        {
            keyCap.button.onClick.AddListener(() =>
            {
                OnKeyPress.Invoke(keyCap.keyCode);
            });
        }
    }
}
