using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberPad : MonoBehaviour
{
    private int maxNumbers = 4;
    private List<int> uniqueNumbers;
    [SerializeField] private List<int> currentCodeList;
    [SerializeField] private List<int> enteredNombersList;
    [SerializeField] private TextMeshProUGUI passCodeText;
    [SerializeField] private TextMeshProUGUI newPassCodeText;
    public GameObject keycardPrefab;
    public GameObject submitAnswer;

    [SerializeField] private Transform spawnPosition;


    void Start()
    {
        uniqueNumbers = new List<int>();
        currentCodeList = new List<int>();
        enteredNombersList = new List<int>();
        GenerateRandomList();
        
    }

    private void GenerateRandomList()
    {
        for (int i = 0; i < 10; i++)
        {
            uniqueNumbers.Add(i);
        }
        for (int i = 0; i < maxNumbers; i++)
        {
            int ranNum = uniqueNumbers[Random.Range(0, uniqueNumbers.Count)];
            currentCodeList.Add(ranNum);
            uniqueNumbers.Remove(ranNum);
        }
        newPassCodeText.SetText("Your Code is: " + currentCodeList[0].ToString() + currentCodeList[1].ToString() + currentCodeList[2].ToString() + currentCodeList[3].ToString());
    }

    public void ProduceCard()
    {
        if (CheckMatch())
        {
            passCodeText.SetText(enteredNombersList[0].ToString() + enteredNombersList[1].ToString() + enteredNombersList[2].ToString() + enteredNombersList[3].ToString());
            Instantiate(keycardPrefab, spawnPosition.position, spawnPosition.rotation);
            submitAnswer.gameObject.GetComponent<BoxCollider>().enabled = false;          
            
        }
        else
        {
            passCodeText.SetText("Invalid Code");

            enteredNombersList.Clear();

        }
    }
    public void RecordEnteredNumbers(int enteredCode)
    {
        if (enteredNombersList.Count < maxNumbers)
        {
            for (int i = 0; i < 1; i++)
            {
                enteredNombersList.Add(enteredCode);
            }
        }
    }

    bool CheckMatch()
    {
        if (currentCodeList.Count != enteredNombersList.Count)
            return false;
        for (int i = 0; i < currentCodeList.Count; i++)
        {
            if (currentCodeList[i] != enteredNombersList[i])
                return false;
        }
        return true;
    }


}
