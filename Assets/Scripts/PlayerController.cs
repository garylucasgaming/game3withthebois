using System;
using System.Collections.Generic;
using UnityEngine;



class PlayerController : MonoBehaviour
{    
    //Computes worldspace positional clamps for the rigid body based
    //on a camera 
    //and allowed min & max screen positions 
    //given as floats from 0-1 (represents a percentage of the viewport)
    private struct PositionClamps
    {
        public Vector2 minPos, maxPos;
        public Camera cam;
        public PositionClamps(Camera cam, float xMin, float xMax, float yMin, float yMax)
        {
            this.cam = cam;
            minPos = new Vector2
                (cam.ViewportToWorldPoint(new Vector3(xMin, 0, 0)).x,
                 cam.ViewportToWorldPoint(new Vector3(0, yMin, 0)).y);

            maxPos = new Vector2
                (cam.ViewportToWorldPoint(new Vector3(xMax, 0, 0)).x,
                 cam.ViewportToWorldPoint(new Vector3(0, yMax, 0)).y);

        }
    }
    private Transform _transform;
    private Collider2D _collider;
    private PositionClamps _positionClamps;

    [SerializeField]
    [Range(0f, 1f)]
    private float _minVerticalScreenPosition;

    [SerializeField]
    [Range(0f, 1f)]
    private float _maxVerticalScreenPosition;

    [SerializeField] private ShipModel _shipModel;
    [SerializeField] private ShipView _shipView;
    public Gun initialGun;

    private Vector2 _directionalInput;
    private int _fireInput;

    private void Awake()
    {
        _transform = _shipModel.transform = GetComponent<Transform>();
        _collider = GetComponent<Collider2D>();

        _positionClamps = new PositionClamps
            (cam: Camera.main,
             xMin: 0,
             xMax: 1,
             yMin: _minVerticalScreenPosition,
             yMax: _maxVerticalScreenPosition);
        _shipModel.projectileSpawnPoints = new Transform[]
        {
            transform.GetChild(0),
            transform.GetChild(1),
            transform.GetChild(2)
        };

        _shipModel.UpdateGun(initialGun);
    }

    private void Update()
    {
        if (!_shipModel.isDead)
        {
            UpdateInput();
            HandleShooting();
        }
        if (_shipModel.isDead) OnDeath();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void UpdateInput()
    {
        _directionalInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));
        _fireInput = (int)Input.GetAxisRaw("Fire1");
    }

    private void HandleMovement()
    {
        _shipModel.Move(_directionalInput);
        ClampModelToViewport();
    }

    public void ClampModelToViewport()
    {
        _transform.position = new Vector2
           (Mathf.Clamp
               (_transform.position.x,
                _positionClamps.minPos.x + _collider.bounds.extents.x,
                _positionClamps.maxPos.x - _collider.bounds.extents.x),
            Mathf.Clamp
               (_transform.position.y,
                _positionClamps.minPos.y + _collider.bounds.extents.y,
                _positionClamps.maxPos.y - _collider.bounds.extents.y));
    }

    private void HandleShooting()
    {
        if (_fireInput > 0) _shipModel.FireGun(Vector2.up);
    }

    public void OnDeath()
    {
        _shipView.OnDeath();
    }
}
