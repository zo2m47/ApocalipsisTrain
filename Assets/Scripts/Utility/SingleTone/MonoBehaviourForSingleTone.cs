using UnityEngine;
using System.Collections.Generic;
/**
 * Creat single tone og game object
 * */
public class MonoBehaviourForSingleTone : MonoBehaviour
{
    //name of gameObject container
    protected const string MAIN_GO = "SingleToneClasses";

    protected const string MANAGER_OBJECT_NAME = "ManagerSingleToneScripts";
    protected const string MODEL_OBJECT_NAME = "ModelSingleToneScripts";
    protected const string CONTROLLER_OBJECT_NAME = "ControllerSingleToneScripts";

    private static GameObject _s_mainScriptsContainer;
    private static Dictionary<string, GameObject> _s_singleToneContainers = new Dictionary<string, GameObject>();

    protected static T SingletonMonoBehaviourInstance<T>() where T : SingletonMonoBehaviour<T>
    {
        if (_s_mainScriptsContainer == null)
        {
            _s_mainScriptsContainer = new GameObject(MAIN_GO);
        }
        //creat game obgect to add component there
        GameObject currentScriptGO = new GameObject("tempGO");
        currentScriptGO.AddComponent<T>();

        T instance = currentScriptGO.GetComponent<T>();

        string currentGOName = instance.GetType().Name;
        string parentGOName = instance.gameObjecName;

        currentScriptGO.name = currentGOName;

        if (parentGOName != "")
        {
            if (!_s_singleToneContainers.ContainsKey(parentGOName))
            {
                GameObject go = new GameObject(parentGOName);
                go.transform.parent = _s_mainScriptsContainer.transform;

                _s_singleToneContainers.Add(parentGOName, go);
            }

            currentScriptGO.transform.parent = _s_singleToneContainers[parentGOName].transform;
        } else
        {
            currentScriptGO.transform.parent = _s_mainScriptsContainer.transform;
        }

        
        return instance;
    }

}
