using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VNOrchestrator : MonoBehaviour
{
    public TMP_Text nameTagText;
    public TMP_Text wordText;
    public TMP_Text optionText;
    public GameObject optionPanel;
    public Image spriteImage;
    public Sprite pout;
    public Sprite unpout;
    public Animator anim;
    public bool triggerThing = false;
    public void Start()
    {
        StartCoroutine(PlayCR());
    }

    public void Click()
    {
        triggerThing = true;
    }

    public IEnumerator PlayCR()
    {
        // blurry
        yield return PlayDialogueCR("Usagi", "Sensei...Wake up!");
        yield return WaitForClickCR();
        // unblur
        yield return PlayDialogueCR("Usagi", "Let's hurry up now!");
        yield return WaitForClickCR();
        yield return PlayDialogueCR("Usagi", "We need to check out the aberration quickly!");
        yield return WaitForClickCR();
        // What is the aberration?
        yield return ShowOptionCR("What is an aberration?");
        // 
        spriteImage.sprite = pout;
        yield return PlayDialogueCR("Usagi", "Are you still half asleep, Sensei?");
        yield return WaitForClickCR();
        spriteImage.sprite = unpout;
        yield return PlayDialogueCR("Usagi", "Aberration is a departure from what is normal, usual, or expected, typically one that is unwelcome.");
        yield return WaitForClickCR();
        spriteImage.sprite = pout;
        yield return PlayDialogueCR("Usagi", "You should know this!  We were on our way to the aberrant archives after all.");
        yield return WaitForClickCR();
        // 
        // What is the aberrant archives?
        yield return ShowOptionCR("What is the aberrant archives?");
        yield return PlayDialogueCR("Usagi", "How have you forgotten that Sensei? Aberrant Archive is the title of the game!");
        yield return WaitForClickCR();
        spriteImage.sprite = unpout;
        yield return PlayDialogueCR("Usagi", "We're supposed to secure, contain and protect all the aberrations so that they wouldn't hurt anyone in public!");
        yield return WaitForClickCR();
        yield return PlayDialogueCR("Usagi", "Let's make to sure you get some more sleep once we get back home, Sensei!");
        yield return WaitForClickCR();
        anim.SetBool("Fade", true);
        yield return PlayDialogueCR("Director", "Cut.");
        yield return WaitForClickCR();
        yield return PlayDialogueCR("Director", "Good job everyone!");
        yield return WaitForClickCR();
        yield return PlayDialogueCR("Director", "Now let's load the Game scene before ");
        yield return null;
        SceneManager.LoadScene("Game");
    }

    public IEnumerator WaitForClickCR()
    {
        triggerThing = false;
        yield return new WaitUntil(() => triggerThing);
    }

    public IEnumerator PlayDialogueCR(string nameTag, string words)
    {
        triggerThing = false;
        nameTagText.text = nameTag;
        for (int i = 0; i < words.Length; i++)
        {
            wordText.text = words.Substring(0,i);
            yield return new WaitForSeconds(1f / 30f);
            if (triggerThing == true)
            {
                break;
            }
        }

        wordText.text = words;
        yield return null;
    }
    
    public IEnumerator ShowOptionCR(string option)
    {
        triggerThing = false;
        optionText.text = option;
        anim.SetBool("Fade", true);
        optionPanel.SetActive(true);
        
        yield return WaitForClickCR();
        anim.SetBool("Fade", false);
        optionPanel.SetActive(false);
        yield return null;
    }
}
