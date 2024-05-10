using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] private GameObject resultPage;
    [SerializeField] private GameObject result;

    [Header("Result")]
    [SerializeField] private TextMeshProUGUI textHeader;
    [SerializeField] private TextMeshProUGUI textAnswer;
    [SerializeField] private TextMeshProUGUI textMeaning;

    [Header("Button")]
    [SerializeField] private Button nextButton;
    [SerializeField] private Button againButton;

    private void Awake()
    {
        OnEvent();
    }

    private void OnEvent()
    {
        nextButton.onClick.AddListener(OnClickNext);
        againButton.onClick.AddListener(OnClickAgain);
    }

    private void OnClickNext()
    {
        resultPage.SetActive(false);
        User.wordIndex++;
        GameBaseState.stateMachine.ChangeState(new BeforeStartState());
    }

    private void OnClickAgain()
    {
        resultPage.SetActive(false);
        GameBaseState.stateMachine.ChangeState(new BeforeStartState());
    }

    public void ShowResult(WordData wordData, bool isCorrect)
    {
        nextButton.gameObject.SetActive(false);
        againButton.gameObject.SetActive(false);
        result.SetActive(false);

        if (isCorrect)
        {
            result.SetActive(true);
            textHeader.text = isCorrect ? "CORRECT !" : "INCORRECT";
            textAnswer.text = wordData.en.ToUpper();
            textMeaning.text = wordData.th;
            nextButton.gameObject.SetActive(true);
        }
        else
        {
            againButton.gameObject.SetActive(true);
        }

        resultPage.SetActive(true);
    }
}