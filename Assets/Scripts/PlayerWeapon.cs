using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] laserParticleSystems;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100.0f;

    bool isFiring = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessFiring();
        ProcessCrosshair();
        ProcessTargetPoint();
        AimLasers();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {

        foreach (GameObject go in laserParticleSystems)
        {
            var emissionModule = go.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
         //var emissionModule = laserParticleSystem.GetComponent<ParticleSystem>().emission;
         //emissionModule.enabled = isFiring;
        

        
    }

    void ProcessCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    void ProcessTargetPoint()
    {
        Vector3 targetPointPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPos);
    }

    void AimLasers()
    {
        foreach (GameObject laser in laserParticleSystems)
        { 
            Vector3 fireDirection = targetPoint.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
        
}
