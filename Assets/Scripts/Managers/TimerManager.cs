using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimerManager : ManagerSingleTone<TimerManager>, IInitilizationProcess
{
    private Dictionary<Action, CallBackByTimer> _listenerOfTimer = new Dictionary<Action, CallBackByTimer>();

    private double _serverTimer = 0;
    
    private DateTime _startSession;
    /**
     * Initialization process 
     * */
    private EnumInitializationStatus _initializationStatus;
    public EnumInitializationStatus initializationStatus { get { return _initializationStatus; } }
    public string ClassNameInInitialization { get { return "Timer"; } }
    public bool allInitializated { get { return _initializationStatus == EnumInitializationStatus.initializated; } }

    public void StartInitialization()
    {
        //TODO send request to get server time 
        _initializationStatus = EnumInitializationStatus.inProgress;
        SetTimer(TimeUtil.ConvertToTimestamp(DateTime.Now));
    }

    // set server time 
    private void SetTimer(double value)
    {
        _serverTimer = value;
        _startSession = DateTime.Now;

        StartCoroutine(LocalTimerTic());
        _initializationStatus = EnumInitializationStatus.initializated;
    }
    
    /// <summary>
    /// Add listener to timer tic 
    /// </summary>
    /// <param name="callBack"> Call back of timer tic listener</param>
    /// <param name="repeatPerSecond"> period of repeat in seconds</param>
    public void AddTickListener(Action callBack,int repeatPerSecond) {
        if (callBack != null && !_listenerOfTimer.ContainsKey(callBack)) {
            repeatPerSecond = Math.Max(1, repeatPerSecond);
            CallBackByTimer callBackByTimer = new CallBackByTimer(repeatPerSecond);
            _listenerOfTimer.Add(callBack, callBackByTimer);
        }
	}
		
    public void RemoveTickListener(Action callBack) {
        if (_listenerOfTimer.ContainsKey(callBack)) {
            _listenerOfTimer.Remove(callBack);
        }
	}
    
    //time in sesion 
    public IEnumerator LocalTimerTic()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            if (_listenerOfTimer.Values.Count!=0)
            {
                foreach(Action keyCalBack in _listenerOfTimer.Keys)
                {
                    _listenerOfTimer[keyCalBack].counter++;
                    if (_listenerOfTimer[keyCalBack].counter >= _listenerOfTimer[keyCalBack].RepeatPerSecond)
                    {
                        keyCalBack();
                        _listenerOfTimer[keyCalBack].counter = 0;
                    }
                }
            }
        }
        yield break;
    }

    public DateTime GetLocalTime()
    {
        return TimeUtil.UnixTimeStampToLocalDateTime(_serverTimer + SyncTime);
    }

    public DateTime GetUtcTime()
    {
        return TimeUtil.UnixTimeStampToUTCDateTime(_serverTimer + SyncTime);
    }

    public double GetServerTime()
    {
        return _serverTimer + SyncTime;
    }

    private double SyncTime
    {
        get
        {
            return TimeUtil.ConvertToTimestamp(DateTime.Now) - TimeUtil.ConvertToTimestamp(_startSession);
        }
    }
}

public class CallBackByTimer
{
    private int _repeatPerSecond = 1;
    public int RepeatPerSecond { get { return _repeatPerSecond; } }
    public int counter = 0;
    public CallBackByTimer(int r)
    {
        _repeatPerSecond = r;
    }
}

