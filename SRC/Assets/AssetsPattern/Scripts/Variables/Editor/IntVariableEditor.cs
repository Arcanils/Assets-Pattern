using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AssetsPattern
{
	[CustomEditor(typeof(IntVariable))]
	public class IntVariableEditor : GenericVariableEditor<IntVariable, int>
	{
	}
}