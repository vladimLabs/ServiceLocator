using System;
using UnityEngine;
using UnityEngine.UI;

namespace UISwitchingSystem
{
    public interface IFadeService
    {
        void FadeIn(CanvasGroup canvasGroup, float duration);
        void FadeOut(CanvasGroup canvasGroup, float duration);
        void FadeIn(CanvasGroup canvasGroup, float duration, Action onComplete);
        void FadeOut(CanvasGroup canvasGroup, float duration, Action onComplete);
    }
}
