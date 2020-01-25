using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.SoundManager
{    
    public static class SoundManager 
    {

        public enum Sound{
            CharacterWalk,
            CharacterGrab,
            CharacterFall,
            Freeze,
            Gong1,
            Gong2,
            Gong3,

        }


        public static void PlaySound(Sound sound){
            AudioClip s = GetSound(sound);
            GameObject soundObject = new GameObject ("sound");
            AudioSource soundSource = soundObject.AddComponent<AudioSource>();
            soundSource.PlayOneShot(s);
            AudioAssets.DestroySound(soundSource, s.length);
            
        }

        private static AudioClip GetSound (Sound sound){
            foreach (AudioAssets.AudioSound clip in AudioAssets.Get.audioClipsArray){
                if(clip.soundName == sound){
                    return clip.soundClip;
                }
            }
            Debug.LogWarning("No sound Clip found");
            return null;
        }

        

    }
    
}

