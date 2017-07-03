using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrafos.DataStructure
{
    /// <summary>
    /// Classe que representa um grafo.
    /// </summary>
    public class Graph
    {

        #region Atributos

        /// <summary>
        /// Lista de nós que compõe o grafo.
        /// </summary>
        private List<Node> nodes;

        #endregion

        #region Propridades

        /// <summary>
        /// Mostra todos os nós do grafo.
        /// </summary>
        public Node[] Nodes
        {
            get { return this.nodes.ToArray(); }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Cria nova instância do grafo.
        /// </summary>
        public Graph()
        {
            this.nodes = new List<Node>();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Encontra o nó através do seu nome.
        /// </summary>
        /// <param name="name">O nome do nó.</param>
        /// <returns>O nó encontrado ou nulo caso não encontre nada.</returns>
        private Node Find(string name)
        {
            // Implementar
            foreach(Node n in nodes)
            {
                if (n.Name == name)
                    return n;
            }

            return null;
        }

        /// <summary>
        /// Adiciona um nó ao grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser adicionado.</param>
        /// <param name="info">A informação a ser armazenada no nó.</param>
        public void AddNode(string name)
        {
            AddNode(name, null);
        }

        /// <summary>
        /// Adiciona um nó ao grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser adicionado.</param>
        /// <param name="info">A informação a ser armazenada no nó.</param>
        public void AddNode(string name, object info)
        {
            if(Find(name) == null)
                nodes.Add(new Node(name,info));
        }

        /// <summary>
        /// Remove um nó do grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser removido.</param>
        public void RemoveNode(string name)
        {
            // Implementar
            if(Find(name)!=null)
                nodes.Remove(Find(name));
        }

        /// <summary>
        /// Adiciona o arco entre dois nós associando determinado custo.
        /// </summary>
        /// <param name="from">O nó de origem.</param>
        /// <param name="to">O nó de destino.</param>
        /// <param name="cost">O cust associado.</param>
        public void AddEdge(string from, string to, double cost)
        {
           // implementar
            Node f = Find(from);
            Node t = Find(to);

            if(f==null ||t==null)
                throw new Exception("Nos inexistentes");
            else
            {
                f.AddEdge(t,cost);
            }

        }

        /// <summary>
        /// Obtem todos os nós vizinhos de determinado nó.
        /// </summary>
        /// <param name="node">O nó origem.</param>
        /// <returns></returns>
        public Node[] GetNeighbours(string from)
        {
            // Implementar
            Node f = Find(from);
            List<Node> nos = new List<Node>();

            if (f == null)
                throw new Exception("Nos inexistentes");
            else
            {
                foreach(Edge e in f.Edges)
                {
                    nos.Add(e.To);
                }
            }

            return nos.ToArray();
        }

        /// <summary>
        /// Valida um caminho, retornando a lista de nós pelos quais ele passou.
        /// </summary>
        /// <param name="nodes">A lista de nós por onde passou.</param>
        /// <param name="path">O nome de cada nó na ordem que devem ser encontrados.</param>
        /// <returns></returns>
        public bool IsValidPath(ref Node[] nodes, params string[] path)
        {
            Node no;
            int existe = 0;
            List<Node> nos = new List<Node>();
            // Implementar
            for (int i = 0; i < path.Count()-1; i++)
            {
                existe = 0;
                no = Find(path[i]);
                if (no != null)
                {
                    foreach (Edge e in no.Edges)
                    {
                        if (e.To == Find(path[i+1]))
                        {
                            existe = 1;
                            nos.Add(no);
                        }
                    }
                }
                if (existe == 0)
                {
                    return false;
                }
            }
            nos.Add(Find(path[path.Count()-1]));
            nodes = nos.ToArray();
            return true;
        }

        #endregion

    }
}
