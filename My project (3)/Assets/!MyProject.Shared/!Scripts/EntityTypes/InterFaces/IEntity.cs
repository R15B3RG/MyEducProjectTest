using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity<out TId>
{ 
    TId Id { get; }

}
    

