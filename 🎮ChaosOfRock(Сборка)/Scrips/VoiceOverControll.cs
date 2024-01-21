using System.Collections.Generic;
using UnityEngine;

public class VoiceOverControll : MonoBehaviour
{
    public List<AudioSource> audioSource;

   public void BridgeMonolog() { foreach (var i in audioSource) { audioSource[0].Play(); } }

   public void TrapMonolog() { foreach (var i in audioSource) { audioSource[2].Play(); } }

   public void IdeaMonolog() { foreach (var i in audioSource) { audioSource[3].Play(); } }

   public void HpMonolog() { foreach (var i in audioSource) { audioSource[1].Play(); } }

    public void StopMonolog() { foreach (var i in audioSource) { i.Stop(); } }
}
