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
            Notification,
            Checkpoint,
            Throw,
            Whip,
            voice1,
            voice2,
            voice3,
            voice4,
            ducktales
        }
        
        public enum Music{
            idleAmbient,
            Music,
            dynamicRunner,
            youLostyouDumbCunt,
            ducktales
        }

        private static GameObject MusicPlayer;

        public static void PlayMusic(Music music){
            AudioClip m = GetMusic(music);
            AudioSource musicSource;
            if(MusicPlayer == null){
                MusicPlayer = new GameObject("MusicPlayer");
                musicSource = MusicPlayer.AddComponent<AudioSource>();
            }else{
                musicSource = MusicPlayer.GetComponent<AudioSource>();
            }

            musicSource.loop = true;
            musicSource.clip = m;
            musicSource.Play();
        }

        public static void PlaySound(Sound sound){
            AudioClip s = GetSound(sound);
            GameObject soundObject = new GameObject ("sound");
            AudioSource soundSource = soundObject.AddComponent<AudioSource>();
            soundSource.PlayOneShot(s);
            AudioAssets.DestroySound(soundSource, s.length);
            
        }

        private static AudioClip GetMusic (Music music){
            foreach (AudioAssets.AudioMusic clip in AudioAssets.Get.musicClipsArray){
                if(clip.musicName == music){
                    return clip.soundClip;
                }
            }
            Debug.LogWarning("No sound Clip found");
            return null;
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

