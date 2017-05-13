using System;
using UnityEngine;

public class BaseNavigationControls : MonoBehaviour, INavigationControls
{
    public event EventHandler Next;
    public event EventHandler Previous;

    public virtual bool Enabled { get; set; }
    
    protected void DispatchNext()
    {
        if (Next != null)
            Next.Invoke(this, EventArgs.Empty);
    }

    protected void DispatchPrevious()
    {
        if (Previous != null)
            Previous.Invoke(this, EventArgs.Empty);
    }
}
