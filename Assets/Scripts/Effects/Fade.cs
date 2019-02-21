using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public Animator animator;
    public GameObject effectsFade;

    public void Start()
    {
        //busca o componente instanciado na pagina, GameObject (EffectsFade)
        animator = GameObject.Find("EffectsFade").GetComponent<Animator>();
        effectsFade = GameObject.Find("EffectsFade");        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            FadeOutToScene();
        }
    }

    public void FadeOutToScene() {
        //animator.Play("FadeOut");
        animator.SetTrigger("FadeOut");
    }


    public void FadeInToScene()
    {        
        animator.SetTrigger("FadeIn");
    }


}
