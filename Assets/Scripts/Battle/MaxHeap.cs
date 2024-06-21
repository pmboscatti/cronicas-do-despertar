using Assets.Scripts.Model;
using System.Collections.Generic;
using System;
public class MaxHeap
{
    private List<Acao> _elements = new List<Acao>();

    public int Count => _elements.Count;

    public void Insert(Acao element)
    {
        _elements.Add(element);
        HeapifyUp(_elements.Count - 1);
    }

    public Acao ExtractMax()
    {
        if (_elements.Count == 0)
        {
            throw new InvalidOperationException("The heap is empty.");
        }

        Acao max = _elements[0];
        _elements[0] = _elements[_elements.Count - 1];
        _elements.RemoveAt(_elements.Count - 1);
        HeapifyDown(0);

        return max;
    }

    public void IncreaseKey(int novaVelocidade, Personagem personagem)
    {
        int index = _elements.FindIndex(e => e.GetAtor() == personagem);
        if (index == -1)
        {
            throw new InvalidOperationException(" not found in the heap.");
        }

        _elements[index].GetAtor().velocidade = novaVelocidade;
        HeapifyUp(index);
    }
    
    public void DecreaseKey(int novaVelocidade, Personagem personagem)
    {
        int index = _elements.FindIndex(e => e.GetAtor() == personagem);
        if (index == -1)
        {
            throw new InvalidOperationException(" not found in the heap.");
        }

        _elements[index].GetAtor().velocidade = novaVelocidade;
        HeapifyDown(index);
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (_elements[index].GetAtor().velocidade <= _elements[parentIndex].GetAtor().velocidade)
            {
                break;
            }

            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void HeapifyDown(int index)
    {
        while (index < _elements.Count / 2)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int largerChildIndex = leftChildIndex;

            if (rightChildIndex < _elements.Count && _elements[rightChildIndex].GetAtor().velocidade > _elements[leftChildIndex].GetAtor().velocidade)
            {
                largerChildIndex = rightChildIndex;
            }

            if (_elements[index].GetAtor().velocidade >= _elements[largerChildIndex].GetAtor().velocidade)
            {
                break;
            }

            Swap(index, largerChildIndex);
            index = largerChildIndex;
        }
    }

    private void Swap(int index1, int index2)
    {
        var temp = _elements[index1];
        _elements[index1] = _elements[index2];
        _elements[index2] = temp;
    }
}