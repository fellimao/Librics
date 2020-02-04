using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoreQuarto : MonoBehaviour
{
    public Animator estrela;
    // Start is called before the first frame update
    void Start()
    {
        if(ScriptStatic.teste == true)
        {
            estrela.SetBool("Teste_completo", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
