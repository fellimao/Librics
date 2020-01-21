using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Clicar : MonoBehaviour
{
    public GameObject paleta;
    public SpriteRenderer seta1;
    public Sprite selecionado;
    public Sprite seta;
    //public VideoClip videoToPlay;
    public Animator animator;
    private int count = 0;

    void Update()
    {
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

    public void FimAnimacaoTriste()
    {
        animator.SetBool("Errou", false);
    }

}
