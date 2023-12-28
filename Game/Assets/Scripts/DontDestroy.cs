using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
   void awake(){
    DontDestroyOnLoad(gameObject);
   }
   
}
