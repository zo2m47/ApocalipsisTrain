using System;

public interface IUIButton
{
    event EventHandler Selected;

    bool Enabled { get; set; }
}