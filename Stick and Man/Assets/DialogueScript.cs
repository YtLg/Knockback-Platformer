using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameComponent;
    public Image profileComponent;
    public GameObject background;
    public static DialogueScript instance;

    public string[] lines;
    public float textwaitTimer;
    public FreezeController freeze;
    public Sprite icon;
    public string charName;
     
    private int index;
    private int count = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setupContent()
    {
        Debug.Log(charName);
        nameComponent.text = charName;
        profileComponent.sprite = icon;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        freeze.setFrozen(true);
        index = 0;
        background.SetActive(true);
        setupContent();
        textComponent.text = string.Empty;
        gameObject.SetActive(true);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c; 
            yield return new WaitForSeconds(textwaitTimer);
        }
    }

    void NextLine()
    {
        if(index < lines.Length -1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine()); 
        }
        else
        {
            freeze.setFrozen(false);
            gameObject.SetActive(false);
            background.SetActive(false);
        }
    }

    public void setLines(string[] lineInput)
    {
        lines = lineInput;
    }

    public void setIcon(Sprite iconInput)
    {
        icon = iconInput;
    }

    public void setName(string nameInput)
    {
        charName = nameInput;
    }
}
