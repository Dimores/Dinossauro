using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface de movimento, ter� as fun��es(assinaturas) de andar, e de pulo.
interface IMovimento
{
    public void Andar();
    public void Correr();
    public void Pular();
    public void Movimento();
}
