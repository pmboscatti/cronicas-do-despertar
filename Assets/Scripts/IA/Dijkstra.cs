public class Grafo {

        private int V;
        public List<List<int>> listaDeListas = new List<List<int>>();
        public List<int> listaDeDistancias = new List<int>();
        private List<Tuple<int, int>>[] adj;

        public Grafo(int v) {
            V = v;
            adj = new List<Tuple<int, int>>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<Tuple<int, int>>();
        }
        public void mudarPeso(int u, int v, int novoW) {
            for (int i = 0; i < adj[u].Count; i++) {
                if (adj[u][i].Item1 == v) {
                    adj[u][i] = Tuple.Create(v, novoW);
                    break;
                }
            }

            for (int i = 0; i < adj[v].Count; i++) {
                if (adj[v][i].Item1 == u) {
                    adj[v][i] = Tuple.Create(u, novoW);
                    break;
                }
            }
        }
        public void adicionarAresta(int u, int v, int w) {
            adj[u].Add(Tuple.Create(v, w));
            adj[v].Add(Tuple.Create(u, w));
        }
        public void caminhoMaisCurto(int s) {
            var filaPrioridade = new FilaPrioridade<Tuple<int, int>>();
            var dist = new int[V];
            var prev = new int[V];

            for (int i = 0; i < V; i++) {
                dist[i] = int.MaxValue;
                prev[i] = -1;
            }

            filaPrioridade.Inserir(Tuple.Create(0, s));
            dist[s] = 0;

            while (filaPrioridade.Contagem != 0) {
                var u = filaPrioridade.Remover().Item2;

                foreach (var i in adj[u]) {
                    int v = i.Item1;
                    int peso = i.Item2;

                    if (dist[v] > dist[u] + peso) {
                        dist[v] = dist[u] + peso;
                        filaPrioridade.Inserir(Tuple.Create(dist[v], v));
                        prev[v] = u;
                    }
                }
            }

            for (int i = 0; i < V; ++i) {
                listaDeListas.Add(new List<int>());
                listaDeDistancias.Add(dist[i]);
                imprimirCaminho(i, prev);
            }
        }

        private void imprimirCaminho(int vertice, int[] prev) {
            if (vertice == -1) {
                return;
            }
            if (listaDeListas.Count > 0) {
                listaDeListas[listaDeListas.Count - 1].Add(vertice);
            }
            imprimirCaminho(prev[vertice], prev);

        }

        public void Reverse() {
            List<List<int>> listaDeListas = this.listaDeListas;
            foreach (List<int> lista in listaDeListas) {
                lista.Reverse();
            }
            this.listaDeListas = listaDeListas;
        }

    }

    public class FilaPrioridade<T> {
        private readonly List<T> _dados;
        private readonly Comparison<T> _comparar;

        public FilaPrioridade()
            : this(Comparer<T>.Default) {
        }

        public FilaPrioridade(IComparer<T> comparador)
            : this(comparador.Compare) {
        }

        public FilaPrioridade(Comparison<T> comparacao) {
            _dados = new List<T>();
            _comparar = comparacao;
        }

        public void Inserir(T item) {
            _dados.Add(item);
            var indiceFilho = _dados.Count - 1;

            while (indiceFilho > 0) {
                var indicePai = (indiceFilho - 1) / 2;
                if (_comparar(_dados[indiceFilho], _dados[indicePai]) >= 0)
                    break;

                T tmp = _dados[indiceFilho];
                _dados[indiceFilho] = _dados[indicePai];
                _dados[indicePai] = tmp;

                indiceFilho = indicePai;
            }
        }

        public T Remover() {
            var ultimoElemento = _dados.Count - 1;

            var primeiroItem = _dados[0];
            _dados[0] = _dados[ultimoElemento];
            _dados.RemoveAt(ultimoElemento);

            --ultimoElemento;

            var indicePai = 0;
            while (true) {
                var indiceFilho = indicePai * 2 + 1;
                if (indiceFilho > ultimoElemento)
                    break;

                var filhoDireito = indiceFilho + 1;
                if (filhoDireito <= ultimoElemento
                    && _comparar(_dados[filhoDireito], _dados[indiceFilho]) < 0)
                    indiceFilho = filhoDireito;

                if (_comparar(_dados[indicePai], _dados[indiceFilho]) <= 0)
                    break;

                T tmp = _dados[indicePai];
                _dados[indicePai] = _dados[indiceFilho];
                _dados[indiceFilho] = tmp;

                indicePai = indiceFilho;
            }

            return primeiroItem;
        }

        public T VerTopo() {
            T primeiroItem = _dados[0];
            return primeiroItem;
        }

        public int Contagem {
            get { return _dados.Count; }
        }
    }