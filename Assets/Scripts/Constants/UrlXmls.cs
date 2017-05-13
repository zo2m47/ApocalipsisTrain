public class UrlXmls
{
    /* Static data - where are all xml
     * */
    private const string XML_FOLDER = "Xmls/";
    private const string STATIC_DATA = "StaticData/";
    public static string staticData
    {
        get
        {
            return XML_FOLDER + STATIC_DATA;
        }
    }
    //XML names 
    private const string USER_SAVED_DATA = "";
    public static string CARRIAGE_LIST = "CarriageList";
    public static string MISSION_LIST = "MissionList";
    public static string RAILWAY_LIST = "RailwayList";
    public static string TERMINAL_LIST = "TerminalList";
    public static string TRAIN_LIST = "TrainList";

    //user saved data // for testing in fut will save in shared object
    public static string userSavedData
    {
        get
        {
            return XML_FOLDER + USER_SAVED_DATA;
        }
    }
}
