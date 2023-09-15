using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;
using Cinemachine;

public class DashAbility : AbilityBase
{
    [Header("Connections")]
    [SerializeField] private Animator animator = default;
    [SerializeField] private CinemachineFreeLook originalCam = default;
    [Header("Visuals")]
    [SerializeField] private ParticleSystem dashParticle = default;
    public override void Ability()
    {
        animator.SetTrigger("Dash");
        dashParticle.Play();

        Sequence dash = DOTween.Sequence()
        .Insert(0, transform.DOMove(transform.position + (transform.forward * 2), .2f))
        .AppendCallback(() => dashParticle.Stop());


        DOVirtual.Float(40, 50, .1f, SetCameraFOV)
            .OnComplete(() => DOVirtual.Float(50, 40, .5f, SetCameraFOV));
    }

    void SetCameraFOV(float fov)
    {
        originalCam.m_Lens.FieldOfView = fov;
    }

}
