using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;




public class NavigationSystem : MonoBehaviour
{
    public TrailRenderer GuideTrail;
    public GameObject Guide;
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject NavigationUI;
    public GameObject DestinationMarker;
    public GameObject GuideGround;
    [SerializeField] 
    public NavMeshSurface[] pathMeshes;
    public NavMeshSurface walkSurface;
    public GameObject GuideSidewalk;
    public AudioManager audioManager;
    
    
    //create an array of all NavMeshSurfaces with the name "Path Mesh"





    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        GuideTrail.enabled = false;
        //NavMeshSurface navMeshSurface = GetComponent<NavMeshSurface>();
        //navMeshSurface.BuildNavMesh();
    }

    public void EnterNavigationMode()
    {
        //find all objects in the array with the name "Path Mesh" and add a mesh collider to them. if they already have a mesh collider, it will not add another one
        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Path Mesh");

          
        foreach (var obj in objects.Where(obj => obj.GetComponent<MeshCollider>() == null))
        {
            obj.AddComponent<MeshCollider>();          
            obj.AddComponent<NavMeshSurface>();
            obj.tag = "Sidewalk";
            obj.isStatic = true;       
            //NavMeshSurface[] nm = GameObject.FindObjectsOfType<NavMeshSurface>().Where(obj => obj.name == "Path Mesh").ToArray();     
        }

        pathMeshes = GameObject.FindObjectsOfType<NavMeshSurface>().Where(obj => obj.name == "Path Mesh").ToArray();    

        for (int i = 0; i < pathMeshes.Length; i++)
        {
          //pathMeshes[i].BuildNavMesh();
          // Debug.Log("NavMesh Built");
        }
        GuideTrail.enabled = true;
        NavigationUI.SetActive(true);   
    }

    public void ExitNavigationMode()
    {
        Instantiate(Guide, agent.transform.position, Quaternion.identity);
        GuideTrail.enabled = false;
        NavigationUI.SetActive(false);                
    }

    public void SetDestination(Vector3 destination)
    {
        //sets the destination of the agent to the destination point only pathing on the NavMesh

        agent.SetDestination(destination);
        
        //instantiates a destination marker at the destination point for 5 seconds and then destroys it
        GameObject marker = Instantiate(DestinationMarker, destination, Quaternion.identity);
        Destroy(marker, 5);
    }




   
    void Update()
    {
        //if spacebar is clicked and Navigation mode is enabled
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // if raycast hits something with the sidewalk tag then set the destination to the hit point
            if (Physics.Raycast(ray, out hit))
            {
                //if the raycast hits the sidewalk then set the destination to the hit point
                if (hit.collider.tag == "Sidewalk")
                {                       
                    SetDestination(hit.point);
                    Debug.Log("Destination set");
                    audioManager.Play(audioManager.playerNavigation);
                }
            }
            
        }
    }
}
