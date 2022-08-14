using TMPro;
using TwoDoors.Save;
using UnityEngine;
using Zenject;

namespace TwoDoors.GUI
{
    public class RecordView : ITMProUpdater
    {
        [SerializeField] private TextMeshProUGUI _recordText;

        [Inject] private SaveService _saveService;

        #region MonoBehaviour

        private void Start()
        {
            UpdateRecord();
        }

        #endregion

        private void UpdateRecord()
        {
            var text = _saveService.RecordScore.ToString();
            UpdateText(_recordText, text);
        }
    }
}