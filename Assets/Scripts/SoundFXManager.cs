using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.SoundManagerNamespace
{
    public class SoundFXManager : MonoBehaviour
    {
        public AudioSource[] SoundAudioSources;
        public AudioSource[] MusicAudioSources;
        public bool PersistToggle;
        // Start is called before the first frame update
        void Start()
        {
            PlayMusic(0);
        }

        // Update is called once per frame
        public void PlayMusic(int index)
        {
            MusicAudioSources[index].PlayLoopingMusicManaged(1.0f, 1.0f, PersistToggle);
        }
        public void PlaySound(int index)
        {
            SoundAudioSources[index].PlayOneShotSoundManaged(SoundAudioSources[index].clip);
        }
    }
}

