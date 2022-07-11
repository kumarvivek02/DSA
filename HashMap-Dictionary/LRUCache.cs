using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    //public class LRUCache
    //{
    //    Dictionary<int, Node> dict;
    //    Node Head;
    //    Node Tail;
    //    public int Capacity { get; set; }


    //    public LRUCache(int capacity)
    //    {
    //        dict = new Dictionary<int, Node>(capacity);
    //        Capacity = capacity;

    //        Head = new Node(0, 0);
    //        Tail = new Node(0, 0);
    //        Head.next = Tail;
    //        Tail.prev = Head;
    //    }

    //    public int Get(int key)
    //    {
    //        var value = -1;

    //        if (dict.ContainsKey(key))
    //        {
    //            var node = dict[key];
    //            value = node.Value;

    //            Remove(node);
    //            Insert(node);

    //            dict[key] = node;
    //        }

    //        return value;
    //    }

    //    public void Put(int key, int value)
    //    {
    //        if (dict.ContainsKey(key))
    //        {
    //            //No need to check capacity if key already exists
    //            var node = dict[key];
    //            node.Value = value;
    //            Remove(node);
    //            Insert(node);
    //            dict[key] = node;
    //        }
    //        else
    //        {
    //            if (dict.Count >= Capacity)
    //            {
    //                //Remove LRU node
    //                dict.Remove(Tail.prev.Key);
    //                Remove(Tail.prev);

    //                var node = new Node(key, value);
    //                Insert(node);
    //                dict.Add(key, node);
    //            }
    //            else
    //            {
    //                var node = new Node(key, value);
    //                Insert(node);
    //                dict.Add(key, node);
    //            }

    //        }
    //    }

    //    public void Remove(Node node)
    //    {
    //        node.prev.next = node.next;
    //        node.next.prev = node.prev;

    //    }

    //    public void Insert(Node node)
    //    {
    //        Node nextToHead = Head.next;

    //        Head.next = node;
    //        node.prev = Head;

    //        node.next = nextToHead;
    //        nextToHead.prev = node;
    //    }
    //}

    //public class Node
    //{
    //    public int Value { get; set; }
    //    public int Key { get; set; }
    //    public Node? next { get; set; }
    //    public Node? prev { get; set; }

    //    public Node(int key, int value)
    //    {
    //        next = null;
    //        prev = null;
    //        Value = value;
    //        Key = key;
    //    }

    //}
}
