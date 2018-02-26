using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerScript : NetworkBehaviour {

    public float PlaneMaxSpeed;
    public float PlaneSpeed;

    public bool Live;

    public float PlaneMaxFuel;
    public float PlaneFuel;
    private float FuelDownCount = 1f;

    public float PlaneMaxHp;
    public float PlaneHp;

    private Vector3 targetPosition;

    public override void OnStartLocalPlayer()
    {
        Live = true;
        PlaneFuel = PlaneMaxFuel;
        PlaneHp = PlaneMaxHp;
        PlaneSpeed = PlaneMaxSpeed;
    }
    void Update () {
        if(isLocalPlayer)
        {
            if (Live)
            {
                Direction(PlaneSpeed);
                SpeedUpPlane();
            }
        }
    }

    void Direction(float GetSpeed)
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * GetSpeed);
        float angle = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        PlaneFuel -= FuelDownCount * Time.deltaTime;
    }
    
    void SpeedUpPlane()
    {
        if (Input.GetMouseButton(1))
        {
            PlaneSpeed = PlaneMaxSpeed + 3;
            FuelDownCount = 3.5f;
        }
        else
        {
            PlaneSpeed = PlaneMaxSpeed;
            FuelDownCount = 1f;
        }
    }

}
