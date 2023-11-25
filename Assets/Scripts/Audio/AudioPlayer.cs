using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] AudioClip levelUpClip;
    [SerializeField] AudioClip hitClip;
    [SerializeField] AudioClip goblinDeathClip;
    [SerializeField] AudioClip skeletonDeathClip;
    [SerializeField] AudioClip collectPowerupClip;

    public void PlayLevelUpClip()
    {
        AudioSource.PlayClipAtPoint(levelUpClip, transform.position);
    }
    public void PlayHitClip()
    {
        AudioSource.PlayClipAtPoint(hitClip, transform.position);
    }
    public void PlayGoblinDeathClip()
    {
        AudioSource.PlayClipAtPoint(goblinDeathClip, transform.position);
    }
    public void PlaySkeletonDeathClip()
    {
        AudioSource.PlayClipAtPoint(skeletonDeathClip, transform.position);
    }
    public void PlayCollectPowerupClip()
    {
        AudioSource.PlayClipAtPoint(collectPowerupClip, transform.position, 1);
    }
}
