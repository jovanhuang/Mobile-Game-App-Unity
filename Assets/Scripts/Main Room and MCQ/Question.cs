using System;
using System.Collections.Generic;
using UnityEngine;

/// Question class is responsible for the questions and answers to the questions

public enum AnswerType { Multi, Single }

[Serializable()]
public class Answer
{
    /// @param Info is the answer information
    /// @param IsCorrect returns true if answer is the correct option else returns false

    public string       Info        = string.Empty;
    public bool         IsCorrect   = false;

    public Answer () { }
}
[Serializable()]
public class Question {

    /// @param Info is the question information
    /// @param Answers is the answers to the question
    /// @param UseTimer is the time set for the question
    /// @param Type is the type of question (Single - one answer only / Multi - multiple answers)
    /// @param AddScore is the score assigned to the question

    public String       Info        = null;
    public Answer[]     Answers     = null;
    public Boolean      UseTimer    = false;
    public Int32        Timer       = 0;
    public AnswerType   Type        = AnswerType.Single;
    public Int32        AddScore    = 0;

    public Question () { }

    /// GetCorrectAnswers function is called to collect and return correct answers indexes.
    public List<int> GetCorrectAnswers ()
    {
        List<int> CorrectAnswers = new List<int>();
        for (int i = 0; i < Answers.Length; i++)
        {
            if (Answers[i].IsCorrect)
            {
                CorrectAnswers.Add(i);
            }
        }
        return CorrectAnswers;
    }
}