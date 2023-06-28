using UnityEngine;

public class FinishGameView : MonoBehaviour
{
   [SerializeField] private CanvasGroup canvasGroup;
   
   public void Show()
   {
      canvasGroup.alpha = 1;
   }
}
