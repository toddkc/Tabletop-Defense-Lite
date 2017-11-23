namespace TowerDefense{
	using UnityEngine;
	public class WaypointManager : MonoBehaviour {

		//this script may need to be remade for each level, depending on how complicated the layout is
		[Tooltip("The number of paths in this level.")]
		public Path[] paths;

	}
}