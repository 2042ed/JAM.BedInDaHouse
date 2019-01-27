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
        Cover.DOFade(0, 1);

        DOVirtual.DelayedCall(2, () =>
        {
            Cover.DOFade(0, .3f).OnComplete(() =>
            {
                Team.alpha = 0;
                Title.alpha = 1;
                Cover.DOFade(0, 1);
            });
        });
    }

    public void DoPlay()
    {
        SceneManager.LoadScene("gioco");
    }
}
