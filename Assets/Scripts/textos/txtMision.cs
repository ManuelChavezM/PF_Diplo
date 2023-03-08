using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class txtMision : MonoBehaviour
{

    public static txtMision instanceMision;

    public TMP_Text mision;
    private string Zona1 = "Avanza a la siguiente zona";
    private string Zona2 = "Explora y junta recursos antes de continuar la busqueda";
    private string Zona3 = "Acaba con el T-Rex para poder avanzar!!!";
    private string Zona4 = "Encuentra pistas sobre el equipo que desapareció";

    private void Awake()
    {
        instanceMision = this;
    }

    public void txt1()
    {
        mision.text = Zona1;
    }

    public void txt2()
    {
        mision.text = Zona2;
    }
    public void txt3()
    {
        mision.text = Zona3;
    }
    public void txt4()
    {
        mision.text = Zona4;
    }



}
