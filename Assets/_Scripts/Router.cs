using System;
using UnityEngine;

namespace TwoDoors
{
    public static class Router
    {
        public static void Route<T>(Action<T> handler, Collider2D contaiter)
        {
            if (contaiter.GetComponent<T>() != null)
                handler?.Invoke(
                    contaiter.GetComponent<T>()
                    );
        }
    }
}