 using System.Collections;
using System.Collections.Generic;
 using StarterAssets;
 using UnityEngine;
 using UnityEngine.InputSystem;

 public class PlayerInteract : MonoBehaviour
{

    public Camera cam;
    [SerializeField] private float distance = 3f;
    [SerializeField] private bool DebugRaycast;
    [SerializeField]private LayerMask mask;
    private PlayerUI playerUI;
    //public StarterAssetsInputs inputManager;
    
    // Start is called before the first frame update
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        //inputManager = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        //create a ray at the center of the camera, shooting outwards.
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        //Debug Raycast
        if (DebugRaycast)
        {
            Debug.DrawRay(ray.origin, ray.direction * distance);
        }

        RaycastHit hitInfo; // variable to store our collision information
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promptMessage);
                //if (inputManager.Player.Interact.triggered)
                {
                    
                }
            }
        }

    }
}
