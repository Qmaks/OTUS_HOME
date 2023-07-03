using TMPro;
using UnityEngine;

namespace Homeworks_5.Shooter.Scripts.UI
{
    public class TextView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI text;

        public void SetText(string text)
        {
            this.text.text = text;
        }
    }
}
