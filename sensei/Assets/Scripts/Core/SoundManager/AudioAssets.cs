using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.SoundManager{
    public class AudioAssets : MonoBehaviourSingleton<AudioAssets>
    {
        public static void DestroySound(AudioSource sound, float time){
            Destroy(sound.gameObject, time);
        }
    
        public AudioSound[] audioClipsArray;
        
        [System.Serializable]
        public class AudioSound{
            public SoundManager.Sound soundName;
            public AudioClip soundClip;
        }

        public AudioMusic[] musicClipsArray;

        [System.Serializable]
        public class AudioMusic{
            public SoundManager.Music musicName;
            public AudioClip soundClip;
        }
    }
}
