using UnityEngine;
using UnityEngine.UI;

public abstract class BaseProgressBar:MonoBehaviour,IProgressBar
{    
    public Image Bar;
    protected Vector2 _maxBarSize;

    void Awake()
    {
        _maxBarSize = Bar.rectTransform.rect.size;
    }

    public virtual void SetData(float progress) { }
}
