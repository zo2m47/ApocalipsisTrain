using System;
//UIScreen id
public enum EnumUIScreenID
{
    withOutName
}

//UIMenu id
public enum EnumUIMenuID
{
    withOutName,
    navigationMenu,
    headMenu
}

//UI Screen animation status
public enum EnumUIScreenAnimationStatus
{
    deactivate,
    closed,
    opened,
    closing,
    openning
}

//Scree Animation style
public enum EnumUIScreenAnimationType
{
    withOut,
    //horizontal
    slideLeftRight,
    slideRightLeft,
    //vertical
    slideTopBottom,
    slideBottomTop
}
//Menu Animation style
public enum EnumUIMenuAnimationType
{
    withOut,
    //hide by alpha
    alpha,
    //horizontal
    slideLeftRight,
    slideRightLeft,
    //vertical
    slideTopBottom,
    slideBottomTop
}