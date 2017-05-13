using System;
using UnityEngine;

public class UIButtonNavigationControls : BaseNavigationControls
{
    public UIButton BtnNext;
    public UIButton BtnPrevious;

    public override bool Enabled
    {
        set {
            BtnNext.Enabled = value;
            BtnPrevious.Enabled = value;
        }
    }

    private void Awake()
    {
        BtnNext.Selected += BtnNextSelectedHandler;
        BtnPrevious.Selected += BtnPreviousSelectedHandler;
    }
    
    private void BtnNextSelectedHandler(object sender, EventArgs evt)
    {
        DispatchNext();
    }

    private void BtnPreviousSelectedHandler(object sender, EventArgs evt)
    {
        DispatchPrevious();
    }
}
