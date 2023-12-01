namespace Stars.Day01;

public class Day01
{
    public int FindCalibrationValue(string text)
    {
        var firstNumber = string.Empty;
        var lastNumber = string.Empty;

        for (int i = 0; i < text.Length; i++)
        {
            if (Char.IsNumber(text[i]))
            {
                firstNumber = text[i].ToString();
                break;
            }
        }
        
        for (int i = text.Length - 1; i >= 0; i--)
        {
            if (Char.IsNumber(text[i]))
            {
                lastNumber = text[i].ToString();
                break;
            }
        }

        var result = Convert.ToInt32(firstNumber + lastNumber);
        return result;
    }
}