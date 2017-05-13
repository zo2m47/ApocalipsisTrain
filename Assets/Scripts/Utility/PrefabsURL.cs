using System;
using System.Collections.Generic;
using UnityEngine;
/*
 * Class with prefab names and urls 
 * */
public static class PrefabsURL
{
    /* Prefabs Names 
     * */
   
    /* Prefabs locations 
     * */
     //base folder 
    private const string BASE_FOLDER = "Prefabs/";
    private const string SCREENS_FOLDER = "Screens/";
    private const string MENU_FOLDER = "Menu/";
    private const string CONTENT_FOLDER = "Content/";
    private const string GAME_VIEW_FOLDER = "GameView/";

    public const string GAME_VIEW_HORSE_INFO = BASE_FOLDER + GAME_VIEW_FOLDER + "HorseInfo";

    //screens prefab
    public const string MAIN_SCREEN = BASE_FOLDER + SCREENS_FOLDER + "MainScreen";
    public const string STABLE_SCREEN = BASE_FOLDER + SCREENS_FOLDER + "StableScreen";
    public const string STABLEWORKS_SCREEN = BASE_FOLDER + SCREENS_FOLDER + "StableworksScreen";
    public const string STABLEWORK_CATEGORY_SCREEN = BASE_FOLDER + SCREENS_FOLDER + "StableworkCategoryScreen";
    public const string PERFOMANCE_SCREEN = BASE_FOLDER + SCREENS_FOLDER + "PerfomanceScreen";
    public const string RETIRED_HORSE_SCREEN = BASE_FOLDER + SCREENS_FOLDER + "RetiredHorseScreen";
    public const string START_TRAINING_SCREEN = BASE_FOLDER + SCREENS_FOLDER + "StartTrainingScreen";


    //screens menu 
    public const string HEAD_MENU = BASE_FOLDER + MENU_FOLDER + "HeadMenu"; 
}
