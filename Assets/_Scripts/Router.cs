﻿using System;
using UnityEngine;

namespace TwoDoors
{
    public static class Router
    {
        public static bool Route<T>(Collider2D contaiter, Action<T> handler)
        {
            if (contaiter.GetComponent<T>() != null)
            {
                handler?.Invoke(
                    contaiter.GetComponent<T>()
                    );

                return true;
            }

            return false;
        }

        public static bool Route<T>(Collider2D contaiter, params Action[] handlers)
        {
            if (contaiter.GetComponent<T>() != null)
            {
                foreach (var handler in handlers)
                    handler?.Invoke();

                return true;
            }

            return false;
        }
    }
}