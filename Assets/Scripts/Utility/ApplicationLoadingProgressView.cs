using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ApplicationLoadingProgressView : MonoBehaviour
{
    private const int MAX_POINTS = 3;
    [SerializeField]
    private Text _isLoading;
    private int _pointCounter = 0;
    private Dictionary<string, EnumInitializationStatus> _initializationProcess = new Dictionary<string, EnumInitializationStatus>();

  

    private IEnumerator InitializationProcess()
    {
        bool isLoaded = false;
        _isLoading.text = "LOADING";
        while (true) { 
            if (MainInitializationProcess.Instance.initializationStatus != EnumInitializationStatus.initializationError)
            {
                if (_pointCounter > MAX_POINTS)
                {
                    _pointCounter = 0;
                    _isLoading.text = "LOADING";
                }
                else
                {
                    _isLoading.text += ".";
                    _pointCounter++;
                }
                if (!isLoaded && MainInitializationProcess.Instance.allInitializated)
                {
                    isLoaded = true;
                    StartCoroutine(WaitForSecondsProcess());
                }
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                _isLoading.text = "<color=red>ERROR IN LOADING</color>";
                StopCoroutine(InitializationProcess());
            }
        }
    }

    private IEnumerator WaitForSecondsProcess()
    {
        StopCoroutine(InitializationProcess());
        _isLoading.text = "IS LOADED";
        gameObject.SetActive(false);
        yield break;
    }

    public void UpdateClassInitializationStatus(string localClassName,EnumInitializationStatus status)
    {
        return;
        //MB it wiil be halpful
        if (_isLoading == null)
        {
            return;
        }

        if (!_initializationProcess.ContainsKey(localClassName))
        {
            _initializationProcess.Add(localClassName, status);
            UpdateLoadingProgressView();
        } else
        {
            if(_initializationProcess[localClassName] != status)
            {
                _initializationProcess[localClassName] = status;
                UpdateLoadingProgressView();
            }

        }
    }

    public void StartLoading()
    {
        gameObject.SetActive(true);
        StartCoroutine(InitializationProcess());
    }

    private void UpdateLoadingProgressView()
    {
        string loadingDescription = "";
        foreach(string key in _initializationProcess.Keys)
        {
            loadingDescription += "\n" + key + " : " + GetInitializationStatusByEnum(_initializationProcess[key]);
        }
        //_loadingProcess.text = loadingDescription;
    }


    private string GetInitializationStatusByEnum(EnumInitializationStatus initializationStatus)
    {
        string res = "";
        switch (initializationStatus)
        {
            case EnumInitializationStatus.waiting:
                res = "Waiting";
                break;
            case EnumInitializationStatus.inProgress:
                res = "<color=yellow>In Progress</color>";
                break;
            case EnumInitializationStatus.initializated:
                res = "<color=green>Initializated</color>";
                break;
            case EnumInitializationStatus.initializationError:
                res = "<color=red>Initialization Error</color>";
                break;
            default:
                break;
        }
        return res;
    }
}
