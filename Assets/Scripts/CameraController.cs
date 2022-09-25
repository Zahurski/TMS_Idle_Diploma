using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField] private float movementSpeed;

    private UIManager _uiManager;
    
    private Vector3 _newZoom;
    private Vector3 _newPosition;
    private Vector3 _dragStartPosition;
    private Vector3 _dragCurrentPosition;

    private void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        _newPosition = transform.position;
    }

    private void Update()
    {
        if(_uiManager.CurrentScreen != _uiManager.GameScreen) return;
        HandleMouseInput();
        HandleMovementInput();
    }
    
    private void HandleMouseInput()
    {
        //TODO: добавить скролы пальцами
        if (Input.mouseScrollDelta.y >= 0 && camera.orthographicSize >= 5.1)
        {
            camera.orthographicSize -= 1f;
        }
        
        if (Input.mouseScrollDelta.y <= 0 && camera.orthographicSize <= 15)
        {
            camera.orthographicSize += 1f;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;
            
            if(plane.Raycast(ray, out entry))
            {
                _dragStartPosition = ray.GetPoint(entry);
            }
        }

        if (Input.GetMouseButton(0))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;
            
            if(plane.Raycast(ray, out entry))
            {
                _dragCurrentPosition = ray.GetPoint(entry);

                _newPosition = transform.position + _dragStartPosition - _dragCurrentPosition;
            }
        }
    }
    
    private void HandleMovementInput()
    {
        transform.position = Vector3.Lerp(transform.position, _newPosition, movementSpeed * Time.deltaTime);
    }

}