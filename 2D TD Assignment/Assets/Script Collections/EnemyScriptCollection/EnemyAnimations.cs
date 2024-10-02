using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Enemy _enemy;

    private void OnEnable()
    {
        ActionSets.OnEnemyHit += EnemyHit;
        ActionSets.OnEnemyKilled += EnemyDead;
    }

    private void OnDisable()
    {
        ActionSets.OnEnemyKilled -= EnemyDead;
        ActionSets.OnEnemyHit -= EnemyHit;
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float GetCurrentAnimationLength()
    {
        float animationLength = _animator.GetCurrentAnimatorStateInfo(0).length;
        return animationLength;
    }

    private void PlayHurtAnimation()
    {
        _animator.SetTrigger("isHurt");
    }

    private void ResetHurtAnimation()
    {
        _animator.ResetTrigger("isHurt");
    }

    private void PlayDeathAnimation()
    {
        _animator.SetTrigger("isDead");
    }

    private void ResetDeathAnimation()
    {
        _animator.ResetTrigger("isDead");      
    }

    private IEnumerator PlayDead() { 
        PlayDeathAnimation();
        yield return new WaitForSeconds(GetCurrentAnimationLength() + 0.1f);
        ResetDeathAnimation();
    }

    private IEnumerator PlayHurt()
    {
        PlayHurtAnimation();
        yield return new WaitForSeconds(GetCurrentAnimationLength() + 0.1f);
        ResetHurtAnimation();
    }

    private void EnemyHit(Enemy enemy)
    {
        if (_enemy == enemy)
        {
            StartCoroutine(PlayHurt());
        }
    }

    private void EnemyDead(Enemy enemy)
    {
        if (_enemy == enemy)
        {
            StartCoroutine(PlayDead());
        }
    }
}
