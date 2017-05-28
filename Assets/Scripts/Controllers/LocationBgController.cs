using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LocationBgController : MonoBehaviour
{
    private float _width = 0;
    private float _height = 0;

    public float Width {
        get
        {
            SetSize();
            return _width;
        }
    }

    public float Height
    {
        get
        {
            SetSize();
            return _height;
        }
    }

    private void SetSize()
    {
        if (_width == 0 || _height == 0)
        {
            Renderer render = gameObject.GetComponent<Renderer>();
            _width = render.bounds.size.x;
            _height = render.bounds.size.y;
        }
    }
}
