using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NotificationController: MonoBehaviour
{
    
	public GameObject _notificationUi;
    public Text _notificationTitle;
    public GameController _gameController;
    private Store<string> _gameStore;

	//void Start()
	//{
 //       _gameStore = _gameController.GetStore("game");
 //       Messenger<int>.AddListener(EventsConfig.OnIncreaseScoreEvent, NotifyScoreChanged);
	//}

    //public void ShowPopUp(string title) {
    //    _notificationUi.SetActive(true);
    //    _notificationTitle.text = title;
    //}

    //public void DeclinePopUp() {
    //    _notificationUi.SetActive(false);
    //}

    //public void NotifyScoreChanged(int delta) {
    //    int score = _gameStore.GetInteger("score");

    //    if (score > 10) ShowPopUp("#Obtained 10");
    //}

    //private void OnDestroy()
    //{
    //    Messenger<int>.RemoveListener(EventsConfig.OnIncreaseScoreEvent, NotifyScoreChanged);
    //}
}
