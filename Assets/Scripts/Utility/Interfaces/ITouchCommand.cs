using UnityEngine;
/**
 * Controll of touch input 
 * All touchable elements must impimate this interface
 * */
interface ITouchCommand
{
    void TouchClick();
    void TouchMoved(Vector3 movedPosition);
    void TouchStartDrag();
    void TouchStopDrag();
    bool Draggable { get; }
}
