using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface de ataque, ter� as fun��es(assinaturas) de ataques normais e variados
public interface IAtaque
{
    public void AtaqueFraco();
    public void AtaqueForte();
    public void AtaqueDistancia();
}
