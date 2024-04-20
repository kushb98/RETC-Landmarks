using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class NavMeshRT : MonoBehaviour
{ 
   void Start()     
   { 
        //2023+ Only
        NavMeshSurface navMeshSurface = GetComponent<NavMeshSurface>(); 
        navMeshSurface.BuildNavMesh(); 
   }
    
}
