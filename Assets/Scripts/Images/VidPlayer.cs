using System;
using UnityEngine;
using UnityEngine.Video;

namespace Images
{
    public class VidPlayer : MonoBehaviour
    {

        [SerializeField] private string url =
            "https://www.youtube.com/s/_/ytmainappweb/_/js/k=ytmainappweb.kevlar_base.en_US.zJV6JWxi7XA.es5.O/d=0/br=1/rs=AGKMywEvrvkJoOwyT3q3_sZYrCLY08lsQg";

        private VideoPlayer videoPlayer;

        private void Awake()
        {
            videoPlayer = GetComponent<VideoPlayer>();

            if (videoPlayer)
            {
                videoPlayer.url = url;
                videoPlayer.playOnAwake = false;
                videoPlayer.Prepare();

                videoPlayer.prepareCompleted += OnVideoPrepared;
            }
        }

        private void OnVideoPrepared(VideoPlayer source)
        {
            videoPlayer.Play();
        }
    }
}
