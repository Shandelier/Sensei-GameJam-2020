using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.SoundManager{
    public class Spotify : MonoBehaviour
    {
        [SerializeField]
        private bool autoplay = true; 
        
        void Start(){
            if(autoplay && AudioAssets.Get.musicClipsArray != null){
                SoundManager.PlayMusic(SoundManager.Music.Music);
            }
        }
    }
}
