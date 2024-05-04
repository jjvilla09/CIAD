using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
  [SerializeField] private AudioClip soulClip;
  Rigidbody2D soulRB;

  void Awake() {
    soulRB = GetComponent<Rigidbody2D>();
  }

  public void FloatAnimation(float duration, float gscale, float thrust) {
    float time = 0f;
    StartCoroutine(FloatAnimationRoutine());
    IEnumerator FloatAnimationRoutine() {
      // add force to soul with gravity
      if(soulRB != null) {
        soulRB.AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 0), 0f) * thrust, ForceMode2D.Impulse);
        soulRB.gravityScale = gscale;
      }

      // wait some number of seconds
      while (time < duration) {
        yield return null;
        time += Time.deltaTime;
      }

      // remove gravity and forces
      if(soulRB != null) {
        soulRB.gravityScale = 0f;
        soulRB.velocity = Vector2.zero;
      }
    }
  }
}
