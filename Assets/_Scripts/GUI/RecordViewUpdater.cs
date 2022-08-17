using TMPro;
using TwoDoors.Save;
using UnityEngine;
using Zenject;

namespace TwoDoors.GUI
{
    public class RecordViewUpdater : ITMProUpdater
    {
        [SerializeField] protected TextMeshProUGUI[] RecordTexts;

        [Inject] private SaveService _saveService;

        public void UpdateRecordTexts()
        {
            var text = _saveService.RecordScore.ToString();
            foreach (var item in RecordTexts)
                UpdateText(item, text);
        }
    }
}