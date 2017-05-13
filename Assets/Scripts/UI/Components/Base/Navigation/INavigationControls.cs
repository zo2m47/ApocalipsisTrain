using System;

public interface INavigationControls
{
    event EventHandler Next;
    event EventHandler Previous;

    bool Enabled { get; set; }    
}