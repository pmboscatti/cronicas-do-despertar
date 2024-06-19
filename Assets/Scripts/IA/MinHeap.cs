using System;
using System.Collections.Generic;

namespace Assets.Scripts.IA{
public class MinHeap
{
    private List<(int distancia, int vertice)> _elements = new List<(int distancia, int vertice)>();

    public int Count => _elements.Count;

    public void Insert((int distancia, int vertice) element)
    {
        _elements.Add(element);
        HeapifyUp(_elements.Count - 1);
    }

    public (int distancia, int vertice) ExtractMin()
    {
        if (_elements.Count == 0)
        {
            throw new InvalidOperationException("The heap is empty.");
        }

        (int distancia, int vertice) min = _elements[0];
        _elements[0] = _elements[_elements.Count - 1];
        _elements.RemoveAt(_elements.Count - 1);
        HeapifyDown(0);

        return min;
    }

    public void DecreaseKey(int novaDistancia, int vertice)
    {
        int index = _elements.FindIndex(e => e.vertice == vertice);
        if (index == -1)
        {
            throw new InvalidOperationException("Vertice not found in the heap.");
        }

        _elements[index] = (novaDistancia, vertice);
        HeapifyUp(index);
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (_elements[index].distancia >= _elements[parentIndex].distancia)
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
            int smallerChildIndex = leftChildIndex;

            if (rightChildIndex < _elements.Count && _elements[rightChildIndex].distancia < _elements[leftChildIndex].distancia)
            {
                smallerChildIndex = rightChildIndex;
            }

            if (_elements[index].distancia <= _elements[smallerChildIndex].distancia)
            {
                break;
            }

            Swap(index, smallerChildIndex);
            index = smallerChildIndex;
        }
    }

    private void Swap(int index1, int index2)
    {
        var temp = _elements[index1];
        _elements[index1] = _elements[index2];
        _elements[index2] = temp;
    }
}
    
}
