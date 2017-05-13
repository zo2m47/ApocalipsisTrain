interface IUIMenuController
{
    void Init();
    //menu id
    EnumUIMenuID MenuID { get; }
    //hide menu withOutAnimation
    void Hide();
    //show menu withOutAnimation
    void Show();
    //show menu with animation 
    void ShowAnimation();
    //hide with animation
    void HideAnimation();
    //set data 
    object Data { set; }
}
