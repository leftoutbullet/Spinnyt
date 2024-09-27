using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CarterGames.Assets.AudioManager;

public class FloatingText : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    bool lineDone = false;
    //spawn enemies
    public GameObject enemySpawner;
    //SpawnEnemies spawnEnemies;
    public GameObject enemyPrefab;
    public Transform[] frontSideSpawnPoints;

    //add stamina bars
    public GameObject staminaLeft;
    public GameObject staminaRight;

    //bomb
    [SerializeField] private GameObject nuke;

    



    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        //spawnEnemies = enemySpawner.GetComponent<SpawnEnemies>();
       
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (/*Input.GetMouseButtonDown(0) || */lineDone == true)
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
        
        if (index == 4) 
        {
            GameObject enemy = GameObject.Find("Treble");
            Destroy(enemy);
        }
        

    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            AudioManager.instance.Play("Typing", 0.3f);
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(1f);
        lineDone = true;
        if (index == 1)
        {
            SpawnEnemy(frontSideSpawnPoints[Random.Range(0, frontSideSpawnPoints.Length)].position);
        }

        if (index == 3)
        {
            ClearExistingEnemies();
        }
        if (index == 4)
        {
            staminaLeft.SetActive(true);
            staminaRight.SetActive(true);
        }
        if (index ==9)
        {
            nuke.SetActive(true);
        }
        
    }

    void NextLine()
    {
        

        lineDone = false;
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


    void SpawnEnemy(Vector3 position)
    {
        Instantiate(enemyPrefab, position, Quaternion.identity);
        AudioManager.instance.Play("EnemySpawn");
    }

    void ClearExistingEnemies()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
    }

}