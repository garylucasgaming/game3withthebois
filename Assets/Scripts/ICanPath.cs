

using System.Collections.Generic;
using UnityEngine;


public interface ICanPath 
{

    void SetPath(List<Transform> newPath);
    void MoveAlongPath();

   

}
