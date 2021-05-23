using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    Renderer[] renderers;
    private bool _isWrappingX = false;
    private bool _isWrappingY = false;


    void Start()
    {
        renderers = GetComponents<SpriteRenderer>();
    }

    bool CheckRenderers()
    {
        // ���������, ����� �� ���� ���� ������ �������
        foreach (var renderer in renderers)
        {
            if (renderer.isVisible)
            {
                return true;
            }
        }

        return false;
    }

    void Wrap()
    {
        var isVisible = CheckRenderers();

        if (isVisible)
        {
            _isWrappingX = false;
            _isWrappingY = false;
            return;
        }

        if (_isWrappingX && _isWrappingY)
        {
            return;
        }

        var cam = Camera.main;
        var viewportPosition = cam.WorldToViewportPoint(transform.position);
        var newPosition = transform.position;

        if (!_isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            // ������������� � ��������������� ���������� �
            newPosition.x = -newPosition.x;

            _isWrappingX = true;
        }

        if (!_isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
        {
            // ������������� � ��������������� ���������� Y
            newPosition.y = -newPosition.y;

            _isWrappingY = true;
        }
        // ����������� ��������� ������������
        transform.position = newPosition;
    }

    private void Update()
    {
        Wrap();
    }
}
