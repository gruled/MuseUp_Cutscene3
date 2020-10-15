using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class VisibleObject : MonoBehaviour
{
    public List<Material> materials = new List<Material>();
    void Start()
    {
        List<MeshRenderer> meshs = GetComponentsInChildren<MeshRenderer>().ToList();
        foreach (var mesh in meshs)
        {
            Material[] materialsArray = mesh.materials;
            for (int i = 0; i < materialsArray.Length; i++)
            {
                this.materials.Add(materialsArray[i]);
            }
        }
    }


    public void Fade()
    {
        foreach (var material in materials)
        {
            material.color = new Color(material.color.r,material.color.g,material.color.b,0.0f);
        }
    }

    public void Visible()
    {
        StartCoroutine(DoVisible());
    }

    private IEnumerator DoVisible()
    {
        Sequence sequence = DOTween.Sequence();
        foreach (var material in materials)
        {
            sequence.Insert(0.0f,material.DOColor(new Color(material.color.r,material.color.g,material.color.b,1.0f),0.5f) );
            material.color = new Color(material.color.r,material.color.g,material.color.b,0.0f);
        }

        sequence.Play();
        yield return new WaitWhile(sequence.IsPlaying);
    }
}
