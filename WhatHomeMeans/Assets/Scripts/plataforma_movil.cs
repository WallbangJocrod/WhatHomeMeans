﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_movil : MonoBehaviour {

public Transform objetivo;

    //la velocidad en que se mueve la plataforma
    public float velocidad;
    private Vector3 inicio, fin;

	public GameObject Player;
	public GameObject suelo_movible;

	public trigger_plataforma trigger_plataforma;

    private bool disparador;

    bool entrar;

	// Use this for initialization
	void Start () {


        trigger_plataforma = suelo_movible.GetComponentInChildren<trigger_plataforma>();

        if(objetivo !=null)
        {
            //esto es para que el target deje de ser pariente del objeto
            objetivo.parent = null;


            //marcamos que las variables son el objeto y el objetivo
            inicio = transform.position;
            fin = objetivo.position;


            objetivo.position=inicio;

        }


		
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        if(objetivo!= null)
        {


            //se cambia la velocidad a velocidad_nueva porque la funcion "towards" necesita una velocidad delta time
            float velocidad_nueva = velocidad * Time.deltaTime;

            //towards sirve para que el objeto vaya hacia el objetivo
            transform.position = Vector3.MoveTowards(transform.position, objetivo.position, velocidad_nueva);





                //esto es para comprobar : si el objetivo esta en el target regresa el target a la posicion principal de la plataforma...si no lo esta sigue llendo
                
				if(entrar==true)
				{
					Player.transform.parent = suelo_movible.transform;
					objetivo.position=fin;

                    disparador= true;

				}
				else if (entrar==false && disparador)
				{
					Player.transform.parent = null;
					objetivo.position=inicio;

                    disparador=false;
				}
				


            

        }

    }


    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            entrar = true;
        }

    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            entrar = false;
        }
    }

}
