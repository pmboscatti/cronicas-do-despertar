using System;

// referencia: https://github.com/SebLague/Pathfinding/blob/master/Episode%2004%20-%20heap/Assets/Scripts/Heap.cs
public class MinHeap<T> where T : ItemHeap<T>
{
    T[] itens;
    int quantidadeAtual;

    public MinHeap(int tamanhoMax)
    {
        itens = new T[tamanhoMax];
        quantidadeAtual = 0;
    }

    public void Add(T item)
    {
        item.IndiceHeap = quantidadeAtual;
        itens[quantidadeAtual] = item;
        Subir(item);
        quantidadeAtual++;
    }

    public T RemoveFirst()
    {
        T primeiroItem = itens[0];
        quantidadeAtual--;
        itens[0] = itens[quantidadeAtual];
        itens[0].IndiceHeap = 0;
        Descer(itens[0]);
        return primeiroItem;
    }

    public void UpdateItem(T item)
    {
        Subir(item);
    }

    public int Count
    {
        get
        {
            return quantidadeAtual;
        }
    }

    public bool Contains(T item)
    {
        return Equals(itens[item.IndiceHeap], item);
    }
   

    void Subir(T item)
    {
        int pai = (item.IndiceHeap - 1) / 2;

        while(true)
        {
            T itemPai = itens[pai];
            if (item.CompareTo(itemPai) > 0)
            {
                Swap(item, itemPai);
            }
            else break;

            pai = (item.IndiceHeap - 1) / 2;
        }
    }

    void Descer(T item)
    {
        while(true)
        {
            int filhoEsquerda = (item.IndiceHeap * 2 + 1);
            int filhoDireita = (item.IndiceHeap * 2 + 2);

            if (filhoEsquerda < quantidadeAtual)
            {
                int trocaCom = filhoEsquerda;

                if(filhoDireita < quantidadeAtual)
                {
                    // Troca com o maior
                    if (itens[filhoEsquerda].CompareTo(itens[filhoDireita]) < 0)
                    {
                        trocaCom = filhoDireita;
                    }
                }

                if (item.CompareTo(itens[trocaCom]) < 0)
                {
                    Swap(item, itens[trocaCom]);
                }
                else break;

            }
            else break;
        }
    }


    void Swap(T a, T b)
    {
        itens[a.IndiceHeap] = b;
        itens[b.IndiceHeap] = a;
        int aux = a.IndiceHeap;
        a.IndiceHeap = b.IndiceHeap;
        b.IndiceHeap = aux;
    }
}


public interface ItemHeap<T> : IComparable<T> { 
    int IndiceHeap { get; set;}
}