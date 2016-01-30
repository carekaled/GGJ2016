using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class prototipo : MonoBehaviour {
    

    Text pointer; //Tecla que você deve apertar
    private bool iGotIt; //True quando o jogador acerta a tecla
    private bool clicado; //True quando o jogador da um input
	public int timerInt;
    public int timerAgr;
    public float timerFloat;
    public List<string> keyList; //lista de teclas a serem precionadas
    public GameObject spriteOk; 
    public GameObject spriteFail; 

	// Use this for initialization
	void Start () {

        pointer = GameObject.Find("GameText").GetComponent<Text>();

        //Lista de teclas a serem pressionadas
        keyList.Add("0");
        keyList.Add("r");
        keyList.Add("q");
        keyList.Add("e");
        keyList.Add("0");
        keyList.Add("w");
        keyList.Add("e");
        keyList.Add("w");
    }
	
	// Update is called once per frame
	void Update () {

        do
        {
            timerFloat = Time.time;
            timerInt = (int)timerFloat;

            //Pessoa ja ainda n clicou nesse segundo
            if (!clicado)
            {

                //Verifico se ela esta clicando agora
                if (Input.anyKey)
                {
                    clicado = true;
                    //Verifico se era pra ele ter clicado
                    if (keyList[timerAgr] == "0")
                    {
                        //N era pra ter clicado
                        iGotIt = false;
                        Fail();
                        pointer.text = "NOPE";
                    }

                    else {
                        //Podia ter clicado
                        //Verifica se clicou certo
                        if (Input.GetKey(keyList[timerAgr]))
                        {
                            //Clicou certo
                            iGotIt = true;
                            Sucess();
                            pointer.text = "OK";
                        }
                        else {
                            //Clicou errado
                            iGotIt = false;
                            Fail();
                            pointer.text = "NOPE";
                        }
                    }

                }

            }


            //Ja clicou nesse segundo

            else {
                //Nada acontece
            }

            if (timerAgr != timerInt)
            { //Acabou o tempo

                //Verifico se algo for apertado

                if (clicado)
                {
                    //Algo foi apertado
                    if (iGotIt)
                    {
                        Sucess();
                    }
                    else {
                        Fail();
                    }

                }

                else {
                    //Nada foi apertado
                    if (keyList[timerAgr] == "0")
                    { //E era isso mesmo
                        Sucess();
                    }
                    else { //deveria ter sido apertado
                        Fail();
                    }
                }

                //Próximo momento
                timerAgr = timerInt;
                iGotIt = false;
                clicado = false;
                pointer.text = keyList[timerAgr];

            }
        } while (timerAgr <= keyList.Count);

        pointer.text = "GG WP";



    }

    private void Sucess()
    {
        spriteOk.SetActive(true);
        spriteFail.SetActive(false);    
    }

    private void Fail()
    {
        spriteFail.SetActive(true);
        spriteOk.SetActive(false);
    }

}
