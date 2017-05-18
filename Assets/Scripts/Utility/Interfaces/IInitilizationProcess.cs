/**
 * Interface of all initializationed model and controllers
 * */
interface IInitilizationProcess
{
    EnumInitializationStatus initializationStatus { get; }
    void StartInitialization(); //start initialization 
    bool allInitializated { get; } //cheking on all initialization
    string ClassNameInInitialization { get; }
}

