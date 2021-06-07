using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttemptShow : MonoBehaviour
{
    [SerializeField] private Text attempts;

    public void ChangeAttemptsCount(int currentAttempt)
    {
        attempts.text = currentAttempt.ToString();
    }
}
