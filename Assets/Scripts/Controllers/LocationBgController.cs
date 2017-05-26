using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LocationBgController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _locationImage;
    public float Height { get { return _locationImage.bounds.size.y; } }
    public float Width { get { return _locationImage.bounds.size.x; } }
}
