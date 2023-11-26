using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNumber : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject skeleton;

    [Header("Variables")]
    [SerializeField] bool playerLevelNumber;
    [SerializeField] bool skeletonLevelNumber;
    
    Vector3 faceLeftScale = new Vector3(-1, 1, 1);
    Vector3 faceRightScale = new Vector3(1, 1, 1);

    private void Update()
    {
        if (playerLevelNumber)
        {
            if(player.transform.localScale.x == -1) { transform.localScale = faceLeftScale; }
            if(player.transform.localScale.x == 1) { transform.localScale = faceRightScale; }
        }

        if (skeletonLevelNumber)
        {
            if(skeleton.transform.localScale.x == -1) { transform.localScale = faceLeftScale; }
            if(skeleton.transform.localScale.x == 1) { transform.localScale = faceRightScale; }
        }
    }
}
