using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Clicar : MonoBehaviour
{
    public GameObject paleta;
    public SpriteRenderer seta1;
    public Sprite selecionado;
    public Sprite seta;
    //public VideoClip videoToPlay;
    public Animator animator;
    public Animator premio;
    private int count = 0;
    private bool acertou = false;
    private bool finito = false;
    private float timeLeft = 3;

    void Update()
    {
        if(acertou == true)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft <= 0)
        {
            premio.SetBool("Acertou", true);
            finito = true;
        }
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.name == "Paleta")
                {
                    animator.SetBool("Acertou", true);
                    acertou = true;
                    //var videoPlayer = fundo.gameObject.GetComponent<VideoPlayer>();
                    //videoPlayer.clip = videoToPlay;
                }
                else
                {
                    count++;
                    if (count > 2)
                        seta1.sprite = seta;
                    var imagem = paleta.GetComponent<SpriteRenderer>();
                    imagem.sprite = selecionado;
                    animator.SetBool("Errou", true);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.name == "Paleta")
            {
                animator.SetBool("Acertou", true);
                acertou = true;
                //var videoPlayer = fundo.gameObject.GetComponent<VideoPlayer>();
                //videoPlayer.clip = videoToPlay;
            }
            if(hit.collider.gameObject.name == "Estrela" && finito == true){
                ScriptStatic.teste = true;
                loadScene("Premios");
            }
            else
            {
                count++;
                if (count > 2)
                    seta1.sprite = seta;
                var imagem = paleta.GetComponent<SpriteRenderer>();
                imagem.sprite = selecionado;
                animator.SetBool("Errou", true);
            }
        }
    }

    public void FimAnimacaoTriste()
    {
        animator.SetBool("Errou", false);
    }

    public void loadScene(string level)
    {
        SceneManager.LoadScene(level);
    }
}
