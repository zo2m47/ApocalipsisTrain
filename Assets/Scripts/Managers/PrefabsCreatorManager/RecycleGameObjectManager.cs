using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * Add this class to prefab who can be create many time
 * */
public class RecycleGameObjectManager : MonoBehaviour
{

    private List<IRecyle> recycleComponents;

    void Awake()
    {
        //Get all component who can be Recycle
        var components = GetComponents<MonoBehaviour>();
        recycleComponents = new List<IRecyle>();
        foreach (var component in components)
        {
            if (component is IRecyle)
            {
                recycleComponents.Add(component as IRecyle);
            }
        }
    }
    //prefab does't destroy it stays activate and call Shutdown all class who implement IRecyle
    public void Restart()
    {
        gameObject.SetActive(true);

        foreach (var component in recycleComponents)
        {
            component.Restart();
        }
    }
    //prefab does't destroy it stays enable and call Restartin all class who implement IRecyle
    public void Shutdown()
    {
        gameObject.SetActive(false);

        foreach (var component in recycleComponents)
        {
            component.Shutdown();
        }
    }

}
