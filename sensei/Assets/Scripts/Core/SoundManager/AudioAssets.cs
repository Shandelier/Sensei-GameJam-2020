using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.SoundManager{
    public class AudioAssets : MonoBehaviourSingleton<AudioAssets>
    {
        public static void DestroySound(AudioSource sound, float time){
            Destroy(sound.gameObject, time);
        }
        // private static AudioAssets _i;
        // public static AudioAssets i {
        //     get{
        //         if(_i == null) 
        //         _i = Instantiate(Resources.Load<AudioAssets>("AudioAssets/"));
        //         return _i; 
        //     }
        // }
        public AudioSound[] audioClipsArray;
        
         [System.Serializable]
        public class AudioSound{
            public SoundManager.Sound soundName;
            public AudioClip soundClip;
        }
    }
}
