using System;
// Initialization statuses 
public enum EnumInitializationStatus
{
    waiting,
    inProgress,
    initializated,
    initializationError
}

public enum EnumStaticDataType
{
    withOutType,
    carriage,
    mission,
    railway,
    terminal,
    train
}
//static data state in market
public enum EnumMarketState
{
    unvisible, //doesnt show in market it
    close, //show, but player can not buy it
    open, //user can buy it
    purchased // уже купленый 
}


public enum EnumStaticDataState
{
    withOutState,
    closed,
    opened,
    pusrchased,
    passed
}

