using UnityEngine;
using UnityEngine.UI;

public class ProgressBarExtra:BaseProgressBar
{    
    public Image ExtraBar;

    public void SetData(float progress, float extraProgress=0)
    {
        if (progress > 1)
            progress = 1;

        if ((progress + extraProgress) > 1)
            extraProgress = 1 - progress;

        Bar.rectTransform.sizeDelta = new Vector2(progress * _maxBarSize.x, _maxBarSize.y);
        ExtraBar.rectTransform.sizeDelta = new Vector2(extraProgress * _maxBarSize.x, _maxBarSize.y);
    }
}
