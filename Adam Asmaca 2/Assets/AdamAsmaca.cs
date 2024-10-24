using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class AdamAsmaca : MonoBehaviour
{
    public string secretWord = "vitamin"; 
    public char[] guessedLetters; 
    public int remainingLives = 6; 
    public bool isGameOver = false; 

    
    public TextMeshProUGUI wordDisplay; 
    public TextMeshProUGUI resultText; 
    public TextMeshProUGUI livesText; 
    public TMP_InputField inputField;
    public Image hangmanImage; 

    
    public Sprite[] hangmanStages;

    void Start()
    {
        
        guessedLetters = new char[secretWord.Length];
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            guessedLetters[i] = '_'; 
        }
        UpdateWordDisplay();
        UpdateLivesDisplay();
    }

    public void CheckLetter()
    {
        if (isGameOver) return; 

       
        if (inputField.text.Length == 0) return;

        char letter = inputField.text.ToLower()[0]; 
        bool found = false;

       
        switch (letter)
        {
            case 'v':
                guessedLetters[0] = 'v';
                found = true;
                break;
            case 'i':
                guessedLetters[1] = 'i';
                guessedLetters[5] = 'i'; 
                found = true;
                break;
            case 't':
                guessedLetters[2] = 't';
                found = true;
                break;
            case 'a':
                guessedLetters[3] = 'a';
                found = true;
                break;
            case 'm':
                guessedLetters[4] = 'm';
                found = true;
                break;
            case 'n':
                guessedLetters[6] = 'n';
                found = true;
                break;
            default:
                remainingLives--; 
                UpdateHangmanImage();
                break;
        }

        if (found)
        {
            UpdateWordDisplay();
        }
        else
        {
            UpdateHangmanImage(); 
        }

        inputField.text = ""; 
        CheckGameOver(); 
        UpdateLivesDisplay();
    }

    private void UpdateWordDisplay()
    {
        wordDisplay.text = ""; 
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            wordDisplay.text += guessedLetters[i] + " "; 
        }
    }

    private void UpdateLivesDisplay()
    {
        livesText.text = "Kalan Can: " + remainingLives;
    }

    private void UpdateHangmanImage()
    {
        hangmanImage.sprite = hangmanStages[6 - remainingLives]; 
    }

    void CheckGameOver()
    {
        if (remainingLives <= 0)
        {
            resultText.text = "Kaybettiniz! Kelime: " + secretWord;
            isGameOver = true;
        }
        else if (IsWordGuessed())
        {
            resultText.text = "Kazandýnýz!";
            isGameOver = true;
        }
    }

    bool IsWordGuessed()
    {
        foreach (char letter in guessedLetters)
        {
            if (letter == '_') return false; 
        }
        return true; 
    }
}
