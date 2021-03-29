using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labo3.Models
{
    public class Arbol
    {
        public class Nodo
        {
            public Nodo Izq, der;
            public char medicamento;
            public Nodo(char medicamento)
            {
                this.medicamento = medicamento;
                this.Izq = null;
                this.der = null;
            }
        }
        Nodo raiz;
        Nodo izquierdo;
        Nodo derecho;
        public Arbol()
        {
            raiz = null;
        }

        public void insertar(char medicamento)
        {
            Nodo nuevo = new Nodo(medicamento);
            if (this.raiz == null)
            {
                this.raiz = nuevo;
            }
            else
            {
                this.raiz = this.insertarnodo(raiz, nuevo);
            }
        }

        public Nodo insertarnodo(Nodo actual, Nodo nuevo)
        {
            if (nuevo.medicamento.CompareTo(actual.medicamento) < 0)
            {
                if (actual.Izq == null)
                {
                    actual.Izq = nuevo;
                    return actual;
                }
                else
                {
                    actual.Izq = insertarnodo(actual.Izq, nuevo);
                }
            }
            else if (nuevo.medicamento.CompareTo(actual.medicamento) > 0)
            {
                if (actual.der == null)
                {
                    actual.der = nuevo;
                    return actual;
                }
                else
                {
                    actual.der = insertarnodo(actual.der, nuevo);
                    return actual;
                }
            }
            else
            {
                return null;
            }
            return null;
        }
        //ROTACIONES
        void RotacionIzquierda(Nodo a, Nodo nodo)
        {
            Nodo Padre = raiz;
            Nodo P = nodo;
            Nodo Q = izquierdo;
            Nodo B = derecho;

            if (Padre == raiz)
                if (derecho == P) derecho = Q;
                else izquierdo = Q;
            else a = Q;

            /* Reconstruir árbol: */
            izquierdo = B;
            derecho = P;

            /* Reasignar padres: */
            Padre = Q;
            if (izquierdo == null) Padre = P;
            Padre = Padre;

        }

        void RotacionDerecha(Nodo a, Nodo nodo)
        {
            Nodo Padre = raiz;
            Nodo P = nodo;
            Nodo B = izquierdo;
            Nodo Q = derecho;

            if (Padre == raiz)
                if (derecho == P) derecho = Q;
                else izquierdo = Q;
            else a = Q;

            /* Reconstruir árbol: */
            izquierdo = B;
            derecho = P;

            /* Reasignar padres: */
            Padre = Q;
            if (izquierdo == null) Padre = P;
            Padre = Padre;

        }
        public void preorden(Nodo raiz)
        {
            if (raiz != null)
            {
                preorden(raiz.Izq);
                preorden(raiz.der);
            }
        }
        public void inorden(Nodo raiz)
        {
            if (raiz != null)
            {
                inorden(raiz.Izq);
                inorden(raiz.der);
            }
        }
        public void postorden(Nodo raiz)
        {
            if (raiz != null)
            {
                postorden(raiz.Izq);
                postorden(raiz.der);
            }
        }
        public void preordenrecur()
        {
            preorden(raiz);
        }
        public void postordenrec()
        {
            postorden(raiz);
        }
        public void inordenrec()
        {
            inorden(raiz);
        }
    }
}