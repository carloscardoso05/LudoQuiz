using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManagerTester : MonoBehaviour
{
    [SerializeField] private QuizManager QuizManager;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //Selecionar Quiz (Q)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            QuizManager.SelectQuiz();
        }
        //Carregar questões fácil, média e difícil (W, E, R)
        if (Input.GetKeyDown(KeyCode.W))
        {
            QuizManager.ShowQuestion(0, null);
        }
        else
        if (Input.GetKeyDown(KeyCode.E))
        {
            QuizManager.ShowQuestion(1, null);
        }
        else
        if (Input.GetKeyDown(KeyCode.R))
        {
            QuizManager.ShowQuestion(2, null);
        }
    }
}
