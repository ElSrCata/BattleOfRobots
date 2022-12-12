using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStart : MonoBehaviour
{
    public GameObject Player;
    public GameObject CameraAnimation;

    private void Update() {
        
        StartCoroutine(time());
    }

    IEnumerator time() {

        yield return new WaitForSeconds(36.0f);
        Destroy(CameraAnimation, 0.1f);
        Player.SetActive(true);
    }
}
