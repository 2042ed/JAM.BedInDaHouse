using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JAM
{
    public class PlaySfx : MonoBehaviour
    {
        public string Usfxr;

        public void Play()
        {
            Debug.Log("PLAY");
            if (Usfxr != "") {
                SfxrSynth synth = new SfxrSynth();
                synth.parameters.SetSettingsString(Usfxr);
                synth.Play();
            }
        }
    }
}