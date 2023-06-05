using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public sealed class ProgressBarView : MonoBehaviour
    {
        [SerializeField] private Image completedImage;
        [SerializeField] private Image fillImage;
        [SerializeField] private TextMeshProUGUI text;
    
        public void SetProgress(float progress)
        {
            fillImage.fillAmount = progress;
            completedImage.enabled = progress == 1.0f;
        }
        
        public void SetText(string _text)
        {
            text.text = _text;
        }
    }
}
