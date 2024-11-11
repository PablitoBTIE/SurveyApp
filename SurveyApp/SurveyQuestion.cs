public class SurveyQuestion
{
    public string QuestionText { get; }
    public bool IsSingleChoice { get; }
    public List<string> Options { get; }

    public SurveyQuestion(string questionText, bool isSingleChoice, List<string> options)
    {
        QuestionText = questionText;
        IsSingleChoice = isSingleChoice;
        Options = options;
    }
}