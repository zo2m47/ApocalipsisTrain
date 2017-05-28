using System;
using UnityEngine;
/**
 * Controller of Camera
 * Add in unity 
 * */
public class CameraNavigationManager : ManagerSingleTone<CameraNavigationManager>,IInitilizationProcess
{
    private const float CAMERA_DRAG_SPEED = 2;
    private const float CAMERA_MOVE_SPEED = 1f;
    private const int CAMERA_ZOOM_SPEED = 50;

    [SerializeField]
    private Camera _mainCamera;

    [SerializeField]
    private int _targetWidth = 1000;
    private int _oldTargetWidth = 0;
    private float _pixelsToUnits = 100;

    [SerializeField]
    private float _cameraMoveSpeed = 10;

    //camera limit
    [SerializeField]
    private float _leftLimit;
    [SerializeField]
    private float _rightLimit;
    [SerializeField]
    private float _topLimit;
    [SerializeField]
    private float _bottomLimit;
    [SerializeField]
    private int _minZoomWidth = 200;

    private Vector3 _newPosition = new Vector3(0,0,0);

    //size 
    private float _bgWidth = 0f;
    private float _bgHeight = 0f;

    private float _oldScreenWidth = 0f;
    private float _oldScreenHeight = 0f;

    private bool _setMaxCameraSize = false;

    /*
     * Initialization process
     * */
    private EnumInitializationStatus _initializationStatus;

    public void StartInitialization()
    {
        _mainCamera = Camera.main;
        _initializationStatus = EnumInitializationStatus.initializated;
    }

    public EnumInitializationStatus initializationStatus
    {
        get
        {
          return _initializationStatus;
        }
    }

    public bool allInitializated
    {
        get
        {
            return _initializationStatus == EnumInitializationStatus.initializated;
        }
    }

    public string ClassNameInInitialization
    {
        get
        {
            return "camera navigation manager";
        }
    }

    //Update is called once per frame
    void Update()
    {
        if (!GameViewManager.Instance.StartShow)
        {
            return;
        }

        if (!MainInitializationProcess.Instance.allInitializated)
        {
            _setMaxCameraSize = true;
            return;
        }

        if (_setMaxCameraSize)
        {
            SetDefaultSettings();
        }
        //set pixels in unit like in background 
       
        if (_targetWidth<_minZoomWidth)
        {
            _targetWidth = _minZoomWidth;
        }

        if (CheckOnNewBGSize() || _targetWidth != _oldTargetWidth || changeViewProportions)
        {
            int height = Mathf.RoundToInt(_targetWidth / (float)Screen.width * Screen.height);
            
            //check on size camera and bg 
            if (height  > GameViewManager.Instance.Height)
            {
                //LoggingManager.AddErrorToLog("HEIGHT TO BIG");
                ZoomCameraIn(CAMERA_ZOOM_SPEED);
                Update();
                return;

            }
            //check on size camera and bg 
            if (_targetWidth  > GameViewManager.Instance.Width)
            {
                //LoggingManager.AddErrorToLog("WIDTH TO BIG");
                ZoomCameraIn(CAMERA_ZOOM_SPEED);
                Update();
                return;
            }

            _oldTargetWidth = _targetWidth;

            if (_mainCamera == null)
            {
                _mainCamera = GetComponent<Camera>();
                if (_mainCamera == null)
                {
                    LoggingManager.AddErrorToLog("Didn't found maint camera");
                }
            }
            
            _mainCamera.orthographicSize = height / 2;

            //set new limits 
            float vertical = _bgWidth  - _targetWidth ;
            float horizontal = _bgHeight  - height ;

            _leftLimit = -1 * vertical / 2;
            _rightLimit = vertical / 2;

            _topLimit = horizontal / 2;
            _bottomLimit = -1 * horizontal / 2;

            CheckOnLimits();
        }

        /*Use for testing 
         * reaction on key 
         * */
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveCameraRight(CAMERA_MOVE_SPEED);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveCameraLeft(CAMERA_MOVE_SPEED);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveCameraDown(CAMERA_MOVE_SPEED);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveCameraUp(CAMERA_MOVE_SPEED);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            ZoomCameraIn(CAMERA_ZOOM_SPEED);
            return;
        }
        if (Input.GetKey(KeyCode.X))
        {
            ZoomCameraOut(CAMERA_ZOOM_SPEED);
            return;
        }

        if (transform.position == _newPosition)
        {
            return;
        }
        float moveSpeed = _pixelsToUnits* _cameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, _newPosition, moveSpeed);
    }

    public void SetDefaultSettings()
    {
        _setMaxCameraSize = false;
        _targetWidth = (int)GameViewManager.Instance.Width;

        _mainCamera.transform.position = new Vector3(0, 0, _mainCamera.transform.position.z);
        _newPosition = new Vector3(0, 0, _mainCamera.transform.position.z); 
        Update();
    }
    
    //check on change view propertion 
    private bool changeViewProportions
    {
        get
        {
            if (Screen.width != _oldScreenWidth || _oldScreenHeight != Screen.height)
            {
                _oldScreenWidth = Screen.width;
                _oldScreenHeight = Screen.height;
                return true;
            }
            return false;
        }
    }

    //check on new background size
    private bool CheckOnNewBGSize()
    {
        if (_bgWidth == GameViewManager.Instance.Width && _bgHeight == GameViewManager.Instance.Height)
        {
            return false;
        }
        _bgWidth = GameViewManager.Instance.Width;
        _bgHeight = GameViewManager.Instance.Height;
        return true;
    }

    /*new Camera position by keyboard
     * for testing 
     * */
    private void MoveCameraLeft(float step)
    {
        _newPosition.x -=step;
        if (_newPosition.x< _leftLimit)
        {
            _newPosition.x = _leftLimit;
        }
    }

    private void MoveCameraRight(float step)
    {
        _newPosition.x += step;
        if (_newPosition.x > _rightLimit)
        {
            _newPosition.x = _rightLimit;
        }
    }

    private void MoveCameraUp(float step)
    {
        _newPosition.y += step;
        if (_newPosition.y > _topLimit)
        {
            _newPosition.y = _topLimit;
        }
    }

    private void MoveCameraDown(float step)
    {
        _newPosition.y -= step;
        if (_newPosition.y < _bottomLimit)
        {
            _newPosition.y = _bottomLimit;
        }
    }

    /*new zoom camera by keyboard
     * */
    private void ZoomCameraIn(int step)
    {
        _targetWidth -=step;
    }

    private void ZoomCameraOut(int step)
    {
        _targetWidth += step;
    }

    /*Check on limits current position
     * */
    private void CheckOnLimits()
    {
        transform.position = _newPosition = GetCorrectPosition(transform.position);
    }

    /*Check on limits
     * */
    private Vector3 GetCorrectPosition(Vector3 position)
    {
        if (position.y < _bottomLimit)
        {
            position.y = _bottomLimit;
        }
        if (position.y > _topLimit)
        {
            position.y = _topLimit;
        }
        if (position.x > _rightLimit)
        {
            position.x = _rightLimit;
        }
        if (position.x < _leftLimit)
        {
            position.x = _leftLimit;
        }
        return position;
    }

    /*Drag camera by touch
     * */
    public void MoveToNewPosition(Vector3 distance)
    {
        _newPosition = GetCorrectPosition(_newPosition + distance);
    }


    /* Camera position
     * */
    public float cameraXPosition
    {
        get
        {
            return gameObject.transform.position.x;
        }
    }
    public float cameraYPosition
    {
        get
        {
            return gameObject.transform.position.y;
        }
    }

}