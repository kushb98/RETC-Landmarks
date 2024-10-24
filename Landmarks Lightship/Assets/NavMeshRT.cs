using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using System.Linq;


public class NavMeshRT : MonoBehaviour
{

    public NavMeshSurface[] pathMeshes;

    void Start()
    {
        //2023+ Only
        NavMeshSurface navMeshSurface = GetComponent<NavMeshSurface>(); 
        navMeshSurface.BuildNavMesh(); 
        pathMeshes = GameObject.FindGameObjectsWithTag("Sidewalk").Select(obj => obj.GetComponent<NavMeshSurface>()).ToArray();
        // pathMeshes = GameObject.FindObjectsOfType<NavMeshSurface>().Where(obj => obj.name == "Path Mesh").ToArray();
        // NavMeshSurface[] pathMeshes = GameObject.FindObjectsOfType<NavMeshSurface>().Where(obj => obj.name == "Path Mesh").ToArray();

        // move the pathmeshes up 10 units
        for (int i = 0; i < pathMeshes.Length; i++)
        {
            pathMeshes[i].transform.position = new Vector3(pathMeshes[i].transform.position.x, pathMeshes[i].transform.position.y + 10, pathMeshes[i].transform.position.z);
        }



        for (int i = 0; i < pathMeshes.Length; i++)
        {
        //    pathMeshes[i].BuildNavMesh();
            Debug.Log("NavMesh Built");
        }

    }

}
