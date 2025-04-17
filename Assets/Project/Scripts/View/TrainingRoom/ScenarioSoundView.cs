using UnityEngine;

namespace Project.Scripts.View.TrainingRoom
{
	// Sound play selected sound
	public class ScenarioSoundView : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource;
		[SerializeField] private AudioClip _acSuccess;
		[SerializeField] private AudioClip _acFail;
		public void PlaySuccess(bool isSuccess)
		{
			_audioSource.clip = isSuccess ? _acSuccess : _acFail;
			_audioSource.Play();
		}
	}
}