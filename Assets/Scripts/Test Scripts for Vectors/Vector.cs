using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class Vector : MonoBehaviour
{

	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 direction = Vector3.up;
	[SerializeField]float lenght = 4;
	[SerializeField]Color color = Color.red;
	[SerializeField]string name = "name";

	void OnDrawGizmos ()
	{ 		
		GizmosForVector.DrawVector (origin: origin, direction: direction,
			vectorLenght: lenght, vectorColor: color, name: name);
	}
}



