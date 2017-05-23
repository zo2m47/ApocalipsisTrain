using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * Add this class to prefab who can be create many time
 * */
public class RecycleGameObjectManager : MonoBehaviour
{

    private IRecyle[] _recycleComponents;

    void Awake()
    {
        //Get all component who can be Recycle
        _recycleComponents = gameObject.GetComponentsInChildren<IRecyle>();
    }
    //prefab does't destroy it stays activate and call Shutdown all class who implement IRecyle
    public void Restart()
    {
        gameObject.SetActive(true);

        foreach (IRecyle component in _recycleComponents)
        {
            component.Restart();
        }
    }
    //prefab does't destroy it stays enable and call Restartin all class who implement IRecyle
    public void Shutdown()
    {
        gameObject.SetActive(false);
        foreach (IRecyle component in _recycleComponents)
        {
            component.Shutdown();
        }
    }

}
