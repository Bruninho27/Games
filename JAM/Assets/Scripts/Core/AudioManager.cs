using UnityEngine;

namespace Core
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] AudioSource musicSource;
        [SerializeField] AudioSource SFXSource;
        public AudioClip background;
        public AudioClip errar;
        public AudioClip passouItem;
        public AudioClip novoobjesteira;

        private void Start()
        {
            musicSource.clip = background;
            musicSource.Play();
        }

        public void PlaySfx(AudioClip clip) => SFXSource.PlayOneShot(clip);
    }
}
