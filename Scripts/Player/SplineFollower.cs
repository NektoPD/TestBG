using System;
using SplineMesh;
using UnityEngine;

public class SplineFollower : MonoBehaviour
{
    [SerializeField] private Spline _spline;
    [SerializeField] private float _speed;
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _maxDeviation = 1f;
    [SerializeField] private float _heightOffset = 3f;

    private Transform _transform;
    private float _splineRate = 0f;
    private float _input = 0f;
    private float _lastMousePosition;
    private float _minMouseClamp = -0.3f;
    private float _maxMouseClamp = 0.3f;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        _lastMousePosition = Input.mousePosition.x;
        Disable();
        Place();
    }

    private void Update()
    {
        _input += (Input.mousePosition.x - _lastMousePosition) * _sensitivity;
        _lastMousePosition = Input.mousePosition.x;
        _input = Mathf.Clamp(_input, _minMouseClamp, _maxMouseClamp);
        
        _splineRate += _speed * Time.deltaTime;

        if (_splineRate <= _spline.nodes.Count - 1)
            Place();
    }
    
    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }

    private void Place()
    {
        CurveSample sample = _spline.GetSampleAtDistance(_splineRate);
        
        Vector3 offset = _transform.right * _input;
        Vector3 newPosition = sample.location + offset + Vector3.up * _heightOffset; 

        Vector3 directionToSpline = sample.location - newPosition;
        if (directionToSpline.magnitude > _maxDeviation)
        {
            newPosition = sample.location - directionToSpline.normalized * _maxDeviation + Vector3.up * _heightOffset;
        }

        _transform.localPosition = newPosition;
        _transform.localRotation = sample.Rotation;
    }
    
}
