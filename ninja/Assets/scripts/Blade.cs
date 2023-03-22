using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour

{
    [SerializeField] TrailRenderer trail;
    [SerializeField] bool slicing;
    [SerializeField] Camera mainCamera;
    [SerializeField] Collider bladeCollider;
    [SerializeField] Vector3 bladePosition, direction;
    [SerializeField] LayerMask bladeLayer;
    RaycastHit hit;
    Ray ray;
    [SerializeField] float speed;
    private void Start()
    {
        mainCamera = Camera.main;
        bladeCollider = GetComponent<Collider>();
        trail = GetComponentInChildren<TrailRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            StartSlice();
            bladeCollider.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            StopSlice();
            bladeCollider.enabled = false;
        }

    }
    private void FixedUpdate()
    {
        if (slicing)
        {
            Slicing();
        }
    }
    private void StartSlice()
    {
        Debug.Log("start Slice");
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 400, bladeLayer))
        {
            bladePosition = hit.point;
            transform.position = bladePosition;
            slicing = true;
            trail.Clear();
        }      
    }
    private void Slicing()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 400, bladeLayer))
        {
            bladePosition = hit.point;
            direction = bladePosition - transform.position;
            speed = direction.magnitude / Time.fixedDeltaTime;
            if (speed > 0.8f) 
            { 
                bladeCollider.enabled = true;
                trail.enabled = true;
                
            }
            else 
            { 
                bladeCollider.enabled = false;
                trail.Clear();
                trail.enabled = false;
            }
            transform.position = bladePosition;
        }
        
    }
    private void StopSlice()
    {
        Debug.Log("stop Slice");
        slicing = false;      
    }
}
