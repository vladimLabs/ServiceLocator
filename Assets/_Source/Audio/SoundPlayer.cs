using Core;
using UnityEngine;

namespace Audio
{
    public class SoundPlayer : ISoundPlayer,IService
    {
        private readonly AudioSource _openSoundSource;
        private readonly AudioSource _closeSoundSource;

        public SoundPlayer(AudioSource openSoundSource, AudioSource closeSoundSource)
        {
            _openSoundSource = openSoundSource;
            _closeSoundSource = closeSoundSource;
        }
        
        public void PlayOpenSound()
        {
            _openSoundSource.Play();
        }
        
        public void PlayCloseSound()
        {
            _closeSoundSource.Play();
        }
    }
}