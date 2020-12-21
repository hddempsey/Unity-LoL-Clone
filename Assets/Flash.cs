using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flash : MonoBehaviour
{
    public KeyCode flashKey = KeyCode.F;
    public float offset = 3f;
    public Transform playerTransform;
    public float cooldown = 3f;

    private float cooldownTimer;
    private bool onCooldown;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        onCooldown = false;
        cooldownTimer = cooldown;
        navMeshAgent = playerTransform.GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
 
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else
        {
            onCooldown = false;
        }


        if (Input.GetKey(flashKey) == true && !onCooldown)
        {
            Debug.Log("Flash");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Vector3 dirToFlash = new Vector3(hit.point.x - playerTransform.position.x, 0f, hit.point.z - playerTransform.position.z).normalized;

                playerTransform.position = playerTransform.position + (dirToFlash * offset);
                navMeshAgent.SetDestination(playerTransform.position);
            }

            onCooldown = true;
            cooldownTimer = cooldown;
        }
    }
}
