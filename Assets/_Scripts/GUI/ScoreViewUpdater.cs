using TMPro;
using TwoDoors.Scene;
using UnityEngine;
using Zenject;

namespace TwoDoors.GUI
{
    public class ScoreViewUpdater : ITMProUpdater
    {
        [SerializeField] protected TextMeshProUGUI[] ScoreTexts;

        [Inject] protected Score Score;

        public void UpdateScoreTexts()
        {
            var text = Score.Amount.ToString();
            foreach (var item in ScoreTexts)
                UpdateText(item, text);
        }

        public void Deactivate()
        {
            foreach (var item in ScoreTexts)
                item.gameObject.SetActive(false);
        }
    }
}