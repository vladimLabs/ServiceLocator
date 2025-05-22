using System;
using Core;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UISwitchingSystem
{
    public class FadeService : IFadeService, IService
    {
        public void FadeIn(CanvasGroup canvasGroup, float duration)
        {
            canvasGroup.DOFade(0, duration);
        }

        public void FadeOut(CanvasGroup canvasGroup, float duration)
        {
            canvasGroup.DOFade(1, duration);
        }

        public void FadeIn(CanvasGroup canvasGroup, float duration, Action onComplete)
        { 
            canvasGroup.DOFade(0, duration).OnComplete(()=>onComplete());
        }
        
        public void FadeOut(CanvasGroup canvasGroup, float duration, Action onComplete)
        {
            canvasGroup.DOFade(1, duration).OnComplete(()=>onComplete());
        }
    }
}