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
    private const string TRAINS = "Trains/";
    private const string CARRIAGES = "Carriages/";
    private const string BULLETS = "Bullets/";

    //screens prefab
    public const string MAIN_SCREEN = BASE_FOLDER + SCREENS_FOLDER + "MainScreen";
    public const string GAME_PLAY_SCREEN = BASE_FOLDER + SCREENS_FOLDER + "GamePlayScreen";
    //Ggame view prefabs 
    public const string LOCOMOTIVE_GAME_VIEW = BASE_FOLDER + GAME_VIEW_FOLDER + "LocomotiveView";
    //Game Elemnts 
    public const string TRAIN_GAME_ELEMENT = BASE_FOLDER + GAME_VIEW_FOLDER + TRAINS;
    public const string CARRIAGES_GAME_ELEMENT = BASE_FOLDER + GAME_VIEW_FOLDER + CARRIAGES;
    public const string BULLET_GAME_ELEMENT = BASE_FOLDER + GAME_VIEW_FOLDER + BULLETS;
    //screens menu 
    public const string HEAD_MENU = BASE_FOLDER + MENU_FOLDER + "HeadMenu";
    
}
