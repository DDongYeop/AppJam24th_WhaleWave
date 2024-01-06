using System.Collections;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private float _changeDuration;
    private int _score = 0;
    private int _showScore = 0;
    private int _currentScore;

    private TextMeshProUGUI _text;
    
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScore(int score)
    {
        _currentScore = score;
        _showScore = _score;
        StopAllCoroutines();
        StartCoroutine(UpdateScoreCo());
    }

    private IEnumerator UpdateScoreCo()
    {
        float currentTime = 0;
        while (currentTime < _changeDuration)
        {
            yield return null;
            currentTime += Time.deltaTime;
            float time = currentTime / _changeDuration;
            _score = (int)Mathf.Lerp(_showScore, _currentScore, time);
            _text.text = _score.ToString();
        }

        _text.text = _currentScore.ToString();
    }
}
