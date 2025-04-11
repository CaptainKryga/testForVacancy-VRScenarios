using UnityEngine;

namespace Project.Scripts.View.Sync.Abstract
{
	//Abstract class for group id component
	public class ComponentIdAbstract : MonoBehaviour
	{
		[SerializeField] private int _id;
		public int Id { get => _id; }
	}
}