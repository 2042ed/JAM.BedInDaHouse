using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    CanvasGroup Team;

    [SerializeField]
    CanvasGroup Title;

    [SerializeField]
    CanvasGroup Cover;

    // Start is called before the first frame update
    void Start()
    {
        Team.alpha = 1;
        Title.alpha = 0;
        Cover.alpha = 1;
        Cover.DOFade(0, 3);

        DOVirtual.DelayedCall(4, () =>
        {
            Cover.DOFade(1, 1).OnComplete(() =>
            {
                Team.alpha = 0;
                Title.alpha = 1;
                Cover.DOFade(0, 2);
            });
        });
    }

    public void DoPlay()
    {
        SceneManager.LoadScene("gioco");
    }
}
