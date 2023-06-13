using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface de movimento, ter� as fun��es(assinaturas) de andar, e de pulo.
interface IMovimento
{
    public void Andar(float x, float z);
    public void Correr(float x, float z);
    public void Pular();
}
