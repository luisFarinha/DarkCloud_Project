using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSplash : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyMeteorSplash());
    }

    // Destroys meteor splash after playing it's particle system animation
    private IEnumerator DestroyMeteorSplash()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

}
